using BlazorCrud.Shared.Dictionaries;
using BlazorCrud.Shared.Domain;

namespace BlazorCrud.Server.Application.Abstraction
{
    public interface IBrandService
    {
        Dictionary<int, string> GetBrandsToSelectList();
    }
}
