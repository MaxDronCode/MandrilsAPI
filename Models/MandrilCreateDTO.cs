using System.ComponentModel.DataAnnotations;

namespace MandrilAPI.Models;

public class MandrilCreateDTO
{
    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    [Required]
    public string Surname { get; set; }
}