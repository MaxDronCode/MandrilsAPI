namespace MandrilAPI.Models;

public class Mandril
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Surname { get; set; } = string.Empty;

    public List<Hability>? Habilities { get; set; } = new List<Hability>();
}