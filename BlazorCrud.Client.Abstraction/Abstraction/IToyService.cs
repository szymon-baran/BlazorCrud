using BlazorCrud.Server.Application;
using BlazorCrud.Shared.Dictionaries;
using BlazorCrud.Shared.Domain;

namespace BlazorCrud.Client.Abstraction
{
    public interface IToyService
    {
        List<Toy> Toys { get; set; }
        Dictionary<ToyType, string> ToyTypesToSelectList { get; set; }
        ToyAddEditVM Toy { get; set; }
        ToyAddEditVM AddModel { get; set; }
        Task GetToysList();
        Task AddToy(ToyAddEditVM model);
        Task<ToyAddEditVM> GetToyDetails(int id);
        Task EditToy(ToyAddEditVM model);
        Task DeleteToy(int id);
        Task GetToyTypesToSelectList();
    }
}
