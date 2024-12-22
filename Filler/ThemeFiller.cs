using IKDTematika.Contexts;
using IKDTematika.ThemeSelector;
using FuzzySharp;

namespace IKDTematika.Filler
{
    public class ThemeFiller : IFiller
    {
        private readonly Random rnd = new Random();
        private readonly ISelector _selector;
        public ThemeFiller(ISelector selector) 
        {
            _selector = selector;
        }
        public async Task<IResult> FillEmptyThemes()
        {

            using (var db = new MaxmokmailIkd2Context())
            {
                var aboba = db.Courses.ToList();
                foreach (var course in aboba)
                {
                    var courseSubj = db.CourseSubjects.Where(x => course.Id == x.IdCourse).ToList();
                    if (courseSubj.Count == 0)
                    {
                        var subjs = (await _selector.GetTheme(new() { Subject = course.Name })).disciplineSubjects.Themes;

                        CheckAndFIXCorrectThemes(subjs, db);

                        Console.WriteLine(string.Join("\n", subjs));

                        if (subjs is null) 
                        {
                            return Results.Problem();
                        }

                        int x = 1;
                        foreach (var item in subjs)
                        {
                            db.Add(new Models.DBModels.CourseSubject()
                            {
                                IdCourse = course.Id,
                                IdSubject = db.Subjects.First(x => x.Name.Trim() == item.Trim()).Id,
                                Rank = x++,
                            });
                            await db.SaveChangesAsync();
                        }
                    }
                    else
                    {
                        await Task.Delay(5000);
                        continue;
                    }
                    
                }
            }

            return Results.Ok();
        }

        private string[] CheckAndFIXCorrectThemes(string[] themes, MaxmokmailIkd2Context ctx)
        {
            var sbj = ctx.Subjects.Select(x => x.Name).ToList();
            foreach (var item in themes)
            {
                if (!sbj.Any(x => x.Contains(item)))
                {
                    bool f = false;
                    foreach (var s in sbj)
                    {
                        if (Fuzz.Ratio(item, s) > 70)
                        {
                            f = true;
                            themes[themes.ToList().IndexOf(item)] = s;
                            break;
                        }
                    }
                    if (!f)
                    {
                        themes[themes.ToList().IndexOf(item)] = sbj.ElementAt(rnd.Next(0, themes.Length));
                    }
                }
            }



            return themes;
        }
    }
}
