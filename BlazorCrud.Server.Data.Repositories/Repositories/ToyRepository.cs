using BlazorCrud.Server.Data.Abstraction;
using BlazorCrud.Server.EntityFramework;
using BlazorCrud.Shared.Domain;
using Microsoft.EntityFrameworkCore;

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
            return _context.Toys.Include(x => x.Brand).ToList();
        }

        public async Task<Toy> AddToy(Toy toy)
        {
            _context.Toys.Add(toy);
            await _context.SaveChangesAsync();
            return toy;
        }

        public async Task<Toy> EditToy(Toy toy)
        {
            _context.Toys.Update(toy);
            await _context.SaveChangesAsync();
            return toy;
        }

        public async Task<int> DeleteToy(Toy toy)
        {
            int id = toy.Id;
            _context.Toys.Remove(toy);
            await _context.SaveChangesAsync();
            return id;
        }

        public async Task<Toy> GetToyDetails(int id)
        {
            return await _context.Toys.Include(x => x.Brand).FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception("No toy");
        }
    }
}
