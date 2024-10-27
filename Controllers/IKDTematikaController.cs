using IKDTematika.Models.ApiModels;
using IKDTematika.ThemeSelector;
using Microsoft.AspNetCore.Mvc;

namespace IKDTematika.Controllers;

[Route("api/ikdtematika")]
[ApiController]
public class IKDTematikaController : ControllerBase
{
    private readonly ISelector _themeSelector;
    public IKDTematikaController(ISelector themeSelector)
    {
        _themeSelector = themeSelector;
    }

    [HttpPost("themes")]
    public async Task<IActionResult> GetThemes([FromBody] RequestModel requestModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var res = await _themeSelector.GetTheme(requestModel); 

        return Ok(res);
    }
}
