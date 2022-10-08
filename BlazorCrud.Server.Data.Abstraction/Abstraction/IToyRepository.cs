using BlazorCrud.Shared.Domain;

namespace BlazorCrud.Server.Data.Abstraction
{
    public interface IToyRepository
    {
        List<Toy> GetToysList();
        Toy GetToyDetails(int id);
    }
}
