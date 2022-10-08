using BlazorCrud.Server.Data.Abstraction;
using BlazorCrud.Server.EntityFramework;
using BlazorCrud.Shared.Domain;

namespace BlazorCrud.Server.Data.Repositories
{
    public class ToyRepository : IToyRepository
    {
        #region Dependencies

        private readonly DataContext _context;

        public ToyRepository(DataContext context)
        {
            _context = context;
        }

        #endregion


        public List<Toy> GetToysList()
        {
            return _context.Toys.ToList();
        }

        public Toy GetToyDetails(int id)
        {
            return _context.Toys.FirstOrDefault(x => x.Id == id) ?? throw new Exception("No toy");

        }
    }
}
