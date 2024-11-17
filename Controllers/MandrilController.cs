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
        {
            return NotFound("El mandril solicitado no existe");
        }
        return Ok(mandril);
    }
}