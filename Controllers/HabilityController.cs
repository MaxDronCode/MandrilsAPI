using MandrilAPI.Models;
using MandrilAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace MandrilAPI.Controllers;

[ApiController]
[Route("api/Mandril/{mandrilId}/[controller]")]
public class HabilityController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Hability>> GetHabilities(int mandrilId)
    {
        var mandril = MandrilService.getMandrilById(mandrilId);

        if (mandril == null)
            return NotFound("El mandril solicitado no existe");

        return Ok(mandril.Habilities);
    }

    [HttpGet("{habilityId}")]
    public ActionResult<Hability> GetHability(int mandrilId, int habilityId)
    {
        var mandril = MandrilService.getMandrilById(mandrilId);

        if (mandril == null)
            return NotFound("El mandril solicitado no existe");

        var hability = mandril.Habilities?.FirstOrDefault(h => h.Id == habilityId);

        if (hability == null)
            return NotFound("La habilidad solicitada no existe");

        return Ok(hability);
    }

    [HttpPost]
    public ActionResult<Hability> CreateHability(int mandrilId, HabilityCreateDTO habilityCreateDto)
    {
        var mandril = MandrilService.getMandrilById(mandrilId);

        if (mandril == null)
            return NotFound("El mandril solicitado no existe");

        var habilidadExistente = mandril.Habilities?.FirstOrDefault(h => h.Name == habilityCreateDto.Name);

        if (habilidadExistente != null)
            return BadRequest("La habilidad ya existe");

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
        var mandril = MandrilService.getMandrilById(mandrilId);

        if (mandril == null)
            return NotFound("El mandril solicitado no existe");

        var hability = mandril.Habilities?.FirstOrDefault(h => h.Id == habilityId);

        if (hability == null)
            return NotFound("La habilidad solicitada no existe");

        var sameNameHability = mandril.Habilities?
            .FirstOrDefault(h => h.Id != habilityId && h.Name == habilityCreateDto.Name);

        if (sameNameHability != null)
            return BadRequest("Ya existe una habilidad con el mismo nombre");

        hability.Name = habilityCreateDto.Name;
        hability.Potency = habilityCreateDto.Potency;

        return NoContent();
    }

    [HttpDelete("{habilityId}")]
    public ActionResult DeleteHability(int mandrilId, int habilityId)
    {
        var mandril = MandrilService.getMandrilById(mandrilId);

        if (mandril == null)
            return NotFound("El mandril solicitado no existe");

        var hability = mandril.Habilities?.FirstOrDefault(h => h.Id == habilityId);

        if (hability == null)
            return NotFound("La habilidad solicitada no existe");

        mandril.Habilities?.Remove(hability);

        return NoContent();
    }
}