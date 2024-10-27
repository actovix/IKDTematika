using IKDTematika.Models.ApiModels;

namespace IKDTematika.ThemeSelector;

public class SubjThemeSelector : ISelector
{
    private readonly LinkedDisciplines _linkedDisc;
    private readonly AIThemeSelector _aiThemeSelector;

    public SubjThemeSelector(LinkedDisciplines linkedDisciplines, AIThemeSelector aIThemeSelector)
    {
        _linkedDisc = linkedDisciplines;
        _aiThemeSelector = aIThemeSelector;
    }

    public async Task<ResponceModel> GetTheme(RequestModel requestModel)
    {
        var tmp = new string[5];
        var resp = new ResponceModel()
        {
            disciplineSubjects = new()
            {
                Name = requestModel.Subject
            }
        };

        if (!_linkedDisc.Get.ContainsKey(requestModel.Subject))
        {
            tmp = await _aiThemeSelector.TryGetThemes(requestModel.Subject);
            
            if (tmp is null)
            {
                resp.disciplineSubjects.Themes = _linkedDisc.Get.ElementAt(rnd.Next(0, _linkedDisc.Get.Count())).Value;
                return resp;
            }
            
            resp.disciplineSubjects.Themes = tmp;
            return resp;
        }

        resp.disciplineSubjects.Themes = _linkedDisc.Get[requestModel.Subject];

        return resp;
    }

    private readonly Random rnd = new();
}
