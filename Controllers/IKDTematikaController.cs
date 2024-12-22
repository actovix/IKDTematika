using IKDTematika.Models.ApiModels;
using IKDTematika.ThemeSelector;
using Microsoft.AspNetCore.Mvc;
using Mistral.SDK.DTOs;
using IKDTematika.Filler;

namespace IKDTematika.Controllers;

[Route("api/ikdtematika")]
[ApiController]
public class IKDTematikaController : ControllerBase
{
    private readonly ISelector _themeSelector;
    private readonly IFiller _filler;

    public IKDTematikaController(ISelector themeSelector, IFiller filler)
    {
        _themeSelector = themeSelector;
        _filler = filler;
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

    [HttpGet("fillEmptyThemes")]
    public async Task<IActionResult> FillEmptyThemes()
    {   
        try
        {
            await _filler.FillEmptyThemes();

        }
        catch (Exception ex) 
        {
            return BadRequest(ex.Message);    
        }

        return Ok();
    }
}
