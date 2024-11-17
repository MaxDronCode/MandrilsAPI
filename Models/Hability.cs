using MandrilAPI.Enums;

namespace MandrilAPI.Models;

public class Hability
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public EPotency Potency { get; set; }
}