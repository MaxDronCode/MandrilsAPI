using MandrilAPI.Models;

namespace MandrilAPI.Repository;

public interface MandrilRepo
{
    IEnumerable<Mandril> GetMandrils();

    Mandril? GetMandril(int mandrilId);

    Mandril CreateMandril(Mandril mandril);

    Mandril? UpdateMandril(int mandrilId, Mandril mandril);

    void DeleteMandril(int mandrilId);
}