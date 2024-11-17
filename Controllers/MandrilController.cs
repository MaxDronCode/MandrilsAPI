using MandrilAPI.Helpers;
using MandrilAPI.Models;
using MandrilAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace MandrilAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MandrilController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Mandril>> GetMandrils()
    {
        return Ok(MandrilDataStore.Current.Mandrils);
    }

    [HttpGet("{id}")]
    public ActionResult<Mandril> GetMandril(int id)
    {
        var mandril = MandrilDataStore.Current.Mandrils.FirstOrDefault(m => m.Id == id);

        if (mandril == null)
            return NotFound(Messages.Mandril.NotFound);

        return Ok(mandril);
    }

    [HttpPost]
    public ActionResult<Mandril> CreateMandril(MandrilCreateDTO mandrilCreateDTO)
    {
        var lastMandrilId = MandrilDataStore.Current.Mandrils.Max(x => x.Id);
        var newMandril = new Mandril()
        {
            Id = lastMandrilId + 1,
            Name = mandrilCreateDTO.Name,
            Surname = mandrilCreateDTO.Surname,
        };

        MandrilDataStore.Current.Mandrils.Add(newMandril);

        return CreatedAtAction(nameof(GetMandril),
            new { id = newMandril.Id },
            newMandril
        );
    }

    [HttpPut("{mandrilId}")]
    public ActionResult<Mandril> UpdateMandril(int mandrilId, MandrilCreateDTO mandrilUpdatted)
    {
        var mandril = MandrilDataStore.Current.Mandrils.FirstOrDefault(x => x.Id == mandrilId);

        if (mandril == null)
            return NotFound(Messages.Mandril.NotFound);

        mandril.Name = mandrilUpdatted.Name;
        mandril.Surname = mandrilUpdatted.Surname;

        return NoContent();
    }

    [HttpDelete("{mandrilId}")]
    public ActionResult DeleteMandril(int mandrilId)
    {
        var mandril = MandrilDataStore.Current.Mandrils.FirstOrDefault(x => x.Id == mandrilId);

        if (mandril == null)
            return NotFound(Messages.Mandril.NotFound);

        MandrilDataStore.Current.Mandrils.Remove(mandril);

        return NoContent();
    }
}