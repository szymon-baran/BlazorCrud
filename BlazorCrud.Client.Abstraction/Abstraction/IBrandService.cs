using BlazorCrud.Shared.Domain;

namespace BlazorCrud.Client.Abstraction
{
    public interface IBrandService
    {
        Dictionary<int, string> BrandsToSelectList { get; set; }
        Task GetBrandsToSelectList();
    }
}
