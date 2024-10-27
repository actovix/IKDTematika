

using Newtonsoft.Json;

namespace IKDTematika.ThemeSelector;

public class LinkedDisciplines
{
    public readonly Dictionary<string, string[]> Get;
    public LinkedDisciplines(string path)
    {
        Get = JsonConvert.DeserializeObject<Dictionary<string, string[]>>(File.ReadAllText(path))!;
    }
}
