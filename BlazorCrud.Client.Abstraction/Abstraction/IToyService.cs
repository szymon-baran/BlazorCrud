using BlazorCrud.Shared.Domain;

namespace BlazorCrud.Client.Abstraction
{
    public interface IToyService
    {
        List<Toy> Toys { get; set; }
        Task GetToysList();
        Task<Toy> GetToyDetails(int id);
    }
}
