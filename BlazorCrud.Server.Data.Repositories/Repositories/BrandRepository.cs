using BlazorCrud.Server.Data.Abstraction;
using BlazorCrud.Server.EntityFramework;

namespace BlazorCrud.Server.Data.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        #region Dependencies

        private readonly DataContext _context;

        public BrandRepository(DataContext context)
        {
            _context = context;
        }

        #endregion


        public Dictionary<int, string> GetBrandsToSelectList()
        {
            return _context.Brands.ToDictionary(x => x.Id, x => x.Name);
        }
    }
}
