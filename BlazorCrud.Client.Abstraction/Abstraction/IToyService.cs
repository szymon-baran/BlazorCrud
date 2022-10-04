using BlazorCrud.Shared.Dictionaries;
using BlazorCrud.Shared.Dictionaries.Enums;
using BlazorCrud.Shared.Domain;
using BlazorCrud.Shared.Domain.Models;

namespace BlazorCrud.Client.Abstraction
{
    public interface IToyService
    {
        List<Toy> Toys { get; set; }
        Dictionary<ToyType, string> ToyTypesToSelectList { get; set; }
        Task GetToysList();
        Task GetToyTypesToSelectList();
        Task<Toy> GetToyDetails(int id);
    }
}
