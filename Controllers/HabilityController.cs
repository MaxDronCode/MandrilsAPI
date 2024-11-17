using MandrilAPI.Helpers;
using MandrilAPI.Models;
using MandrilAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace MandrilAPI.Controllers;

[ApiController]
[Route("api/Mandril/{mandrilId}/[controller]")]
public class HabilityController : ControllerBase
{
    private MandrilService mandrilService;

    public HabilityController(MandrilService mandrilService)
    {
        this.mandrilService = mandrilService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Hability>> GetHabilities(int mandrilId)
    {
        var mandril = mandrilService.GetMandril(mandrilId);

        if (mandril == null)
            return NotFound(Messages.Mandril.NotFound);

        return Ok(mandril.Habilities);
    }

    [HttpGet("{habilityId}")]
    public ActionResult<Hability> GetHability(int mandrilId, int habilityId)
    {
        var mandril = mandrilService.GetMandril(mandrilId);

        if (mandril == null)
            return NotFound(Messages.Mandril.NotFound);

        var hability = mandril.Habilities?.FirstOrDefault(h => h.Id == habilityId);

        if (hability == null)
            return NotFound(Messages.Hability.NotFound);

        return Ok(hability);
    }

    [HttpPost]
    public ActionResult<Hability> CreateHability(int mandrilId, HabilityCreateDTO habilityCreateDto)
    {
        var mandril = mandrilService.GetMandril(mandrilId);

        if (mandril == null)
            return NotFound(Messages.Mandril.NotFound);

        var habilidadExistente = mandril.Habilities?.FirstOrDefault(h => h.Name == habilityCreateDto.Name);

        if (habilidadExistente != null)
            return BadRequest(Messages.Hability.NotFound);

        var lastHabilityId = mandril.Habilities?.Max(x => x.Id);

        var newHability = new Hability()
        {
            Id = lastHabilityId.GetValueOrDefault() + 1,
            Name = habilityCreateDto.Name,
            Potency = habilityCreateDto.Potency
        };

        mandril.Habilities?.Add(newHability);

        return CreatedAtAction(nameof(GetHability),
            new { mandrilId, habilityId = newHability.Id },
            newHability
        );
    }

    [HttpPut("{habilityId}")]
    public ActionResult<Hability> UpdateHability(int mandrilId, int habilityId, HabilityCreateDTO habilityCreateDto)
    {
        var mandril = mandrilService.GetMandril(mandrilId);

        if (mandril == null)
            return NotFound(Messages.Mandril.NotFound);

        var hability = mandril.Habilities?.FirstOrDefault(h => h.Id == habilityId);

        if (hability == null)
            return NotFound(Messages.Hability.NotFound);

        var sameNameHability = mandril.Habilities?
            .FirstOrDefault(h => h.Id != habilityId && h.Name == habilityCreateDto.Name);

        if (sameNameHability != null)
            return BadRequest(Messages.Hability.AlreadyExists);

        hability.Name = habilityCreateDto.Name;
        hability.Potency = habilityCreateDto.Potency;

        return NoContent();
    }

    [HttpDelete("{habilityId}")]
    public ActionResult DeleteHability(int mandrilId, int habilityId)
    {
        var mandril = mandrilService.GetMandril(mandrilId);

        if (mandril == null)
            return NotFound(Messages.Mandril.NotFound);

        var hability = mandril.Habilities?.FirstOrDefault(h => h.Id == habilityId);

        if (hability == null)
            return NotFound(Messages.Hability.NotFound);

        mandril.Habilities?.Remove(hability);

        return NoContent();
    }
}