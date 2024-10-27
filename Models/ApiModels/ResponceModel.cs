namespace IKDTematika.Models.ApiModels;

public class ResponceModel
{
    public DisciplineSubjects disciplineSubjects { get; set; } = new();
}

public class DisciplineSubjects
{
    public string Name { get; set; } = "";
    public string[] Themes { get; set; } = [];
}