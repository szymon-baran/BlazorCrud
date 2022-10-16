using BlazorCrud.Shared.Domain;

namespace BlazorCrud.Server.Data.Abstraction
{
    public interface IToyRepository
    {
        List<Toy> GetToysList();
        Task<Toy> AddToy(Toy toy);
        Task<Toy> EditToy(Toy toy);
        Task<int> DeleteToy(Toy toy);
        Task<Toy> GetToyDetails(int id);
    }
}
