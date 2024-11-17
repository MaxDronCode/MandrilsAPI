using MandrilAPI.Models;
using MandrilAPI.Repository;

namespace MandrilAPI.Services;

public class MandrilService
{
    private readonly MandrilRepo mandrilRepo;

    public MandrilService(MandrilRepo mandrilRepo)
    {
        this.mandrilRepo = mandrilRepo;
    }

    public Mandril? GetMandril(int mandrilId)
    {
        return mandrilRepo.GetMandril(mandrilId);
    }

    public IEnumerable<Mandril> GetMandrils()
    {
        return mandrilRepo.GetMandrils();
    }

    public Mandril createMandril(MandrilCreateDTO mandrilCreateDTO)
    {
        var lastMandrilId = mandrilRepo.GetMandrils().Last().Id;
        var newMandril = new Mandril()
        {
            Id = lastMandrilId + 1,
            Name = mandrilCreateDTO.Name,
            Surname = mandrilCreateDTO.Surname
        };

        return mandrilRepo.CreateMandril(newMandril);
    }

    public bool updateMandril(int mandrilId, MandrilCreateDTO mandrilCreateDTO)
    {
        var mandril = mandrilRepo.GetMandril(mandrilId);

        if (mandril == null)
            return false;

        mandril.Name = mandrilCreateDTO.Name;
        mandril.Surname = mandrilCreateDTO.Surname;

        mandrilRepo.UpdateMandril(mandrilId, mandril);

        return true;
    }

    public bool deleteMandril(int mandrilId)
    {
        var mandril = mandrilRepo.GetMandril(mandrilId);

        if (mandril == null)
            return false;

        mandrilRepo.DeleteMandril(mandrilId);
        return true;
    }
}