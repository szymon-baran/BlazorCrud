using BlazorCrud.Shared.Dictionaries;
using BlazorCrud.Shared.Domain;

namespace BlazorCrud.Server.Application.Abstraction
{
    public interface IToyService
    {
        List<Toy> GetToysList();
        Toy GetToyDetails(int id);
        Dictionary<ToyType, string> GetToyTypesToSelectList();
    }
}
