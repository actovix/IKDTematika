using IKDTematika.Models.ApiModels;
using Microsoft.AspNetCore.Mvc;

namespace IKDTematika.Controllers;

[Route("api")]
[ApiController]
public class IKDTematikaController : ControllerBase
{
    public IKDTematikaController()
    {

    }

    [HttpPost("details")]
    public async Task<ResponceModel> GetThemes([FromBody] RequestModel requestModel)
    {
        
    }
}
