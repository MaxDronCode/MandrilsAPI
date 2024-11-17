using MandrilAPI.Helpers;
using MandrilAPI.Models;
using MandrilAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace MandrilAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MandrilController : ControllerBase
{
    private MandrilService mandrilService;

    public MandrilController(MandrilService mandrilService)
    {
        this.mandrilService = mandrilService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Mandril>> GetMandrils()
    {
        return Ok(mandrilService.GetMandrils());
    }

    [HttpGet("{mandrilId}")]
    public ActionResult<Mandril> GetMandril(int mandrilId)
    {
        var mandril = mandrilService.GetMandril(mandrilId);

        if (mandril == null)
            return NotFound(Messages.Mandril.NotFound);

        return Ok(mandril);
    }

    [HttpPost]
    public ActionResult<Mandril> CreateMandril(MandrilCreateDTO mandrilCreateDTO)
    {
        var newMandril = mandrilService.createMandril(mandrilCreateDTO);

        return CreatedAtAction(nameof(GetMandril),
            new { mandrilId = newMandril.Id },
            newMandril
            );
    }

    [HttpPut("{mandrilId}")]
    public ActionResult<Mandril> UpdateMandril(int mandrilId, MandrilCreateDTO mandrilUpdatted)
    {
        var success = mandrilService.updateMandril(mandrilId, mandrilUpdatted);

        if (!success)
            return NotFound(Messages.Mandril.NotFound);

        return NoContent();
    }

    [HttpDelete("{mandrilId}")]
    public ActionResult DeleteMandril(int mandrilId)
    {
        var sucess = mandrilService.deleteMandril(mandrilId);

        if (!sucess)
            return NotFound(Messages.Mandril.NotFound);

        return NoContent();
    }
}