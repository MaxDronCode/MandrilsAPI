using MandrilAPI.Models;

namespace MandrilAPI.Services;

public static class MandrilService
{
    public static Mandril? getMandrilById(int mandrilId)
    {
        return MandrilDataStore.Current.Mandrils.FirstOrDefault(mandril => mandril.Id == mandrilId);
    }
}