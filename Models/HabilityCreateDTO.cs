using System.ComponentModel.DataAnnotations;
using MandrilAPI.Enums;

namespace MandrilAPI.Models;

public class HabilityCreateDTO
{
    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public EPotency Potency { get; set; }
}