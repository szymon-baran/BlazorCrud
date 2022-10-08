namespace BlazorCrud.Server.Data.Abstraction
{
    public interface IBrandRepository
    {
        Dictionary<int, string> GetBrandsToSelectList();
    }
}
