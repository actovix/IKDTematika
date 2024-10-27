using IKDTematika.Models.ApiModels;

namespace IKDTematika.ThemeSelector;

public interface ISelector
{
    public Task<ResponceModel> GetTheme(RequestModel requestModel); 
}
