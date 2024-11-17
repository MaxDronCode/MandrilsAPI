using MandrilAPI.Db;
using MandrilAPI.Models;

namespace MandrilAPI.Repository;

public class MandrilRepoImpl : MandrilRepo
{
    private readonly MandrilDataStore mandrilDataStore;

    public MandrilRepoImpl(MandrilDataStore mandrilDataStore)
    {
        this.mandrilDataStore = mandrilDataStore;
    }

    public Mandril CreateMandril(Mandril mandril)
    {
        mandrilDataStore.Mandrils.Add(mandril);
        return mandril;
    }

    public void DeleteMandril(int mandrilId)
    {
        var mandril = mandrilDataStore.Mandrils.FirstOrDefault(mandril => mandril.Id == mandrilId);

        if (mandril != null)
            mandrilDataStore.Mandrils.Remove(mandril);
    }

    public Mandril? GetMandril(int mandrilId)
    {
        return mandrilDataStore.Mandrils.FirstOrDefault(mandril => mandril.Id == mandrilId);
    }

    public IEnumerable<Mandril> GetMandrils()
    {
        return mandrilDataStore.Mandrils;
    }

    public Mandril? UpdateMandril(int mandrilId, Mandril mandrilUpdated)
    {
        var existingMandril = mandrilDataStore.Mandrils.FirstOrDefault(mandril => mandril.Id == mandrilId);

        if (existingMandril != null)
        {
            existingMandril.Name = mandrilUpdated.Name;
            existingMandril.Surname = mandrilUpdated.Surname;
        }

        return existingMandril;
    }
}