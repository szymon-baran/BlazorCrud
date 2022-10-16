using BlazorCrud.Shared.Dictionaries;
using BlazorCrud.Shared.Domain;

namespace BlazorCrud.Server.Application.Abstraction
{
    public interface IToyService
    {
        List<Toy> GetToysList();
        Task<Toy> AddToy(ToyAddEditVM model);
        Task<ToyAddEditVM> GetToyDetailsVM(int id);
        Task<Toy> EditToy(ToyAddEditVM model);
        Task<int> DeleteToy(int id);
        Dictionary<ToyType, string> GetToyTypesToSelectList();
    }
}
