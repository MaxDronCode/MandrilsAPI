﻿using System.ComponentModel.DataAnnotations;

namespace MandrilAPI.Models;

public class MandrilCreateDTO
{
    [Required]
    [StringLength(50)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string Surname { get; set; } = string.Empty;
}