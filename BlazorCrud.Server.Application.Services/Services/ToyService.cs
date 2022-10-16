using BlazorCrud.Server.Application.Abstraction;
using BlazorCrud.Server.Data.Abstraction;
using BlazorCrud.Shared.Dictionaries;
using BlazorCrud.Shared.Domain;
using System.Reflection;
using System.Runtime.InteropServices;

namespace BlazorCrud.Server.Application.Services
{
    public class ToyService : IToyService
    {
        #region Dependencies

        private readonly IToyRepository _toyRepository;

        public ToyService(IToyRepository toyRepository)
        {
            _toyRepository = toyRepository;
        }

        #endregion


        public List<Toy> GetToysList()
        {
            return _toyRepository.GetToysList();
        }

        public async Task<Toy> AddToy(ToyAddEditVM model)
        {
            Toy toy = new()
            {
                Name = model.Name,
                ToyType = model.ToyType.HasValue ? model.ToyType.Value : ToyType.Figure,
                BrandId = model.BrandId
            };
            return await _toyRepository.AddToy(toy);
        }

        public async Task<ToyAddEditVM> GetToyDetailsVM(int id)
        {
            Toy toy = await _toyRepository.GetToyDetails(id);
            return new ToyAddEditVM()
            {
                Id = toy.Id,
                Name = toy.Name,
                ToyType = toy.ToyType,
                BrandId = toy.BrandId
            };
        }

        public async Task<Toy> EditToy(ToyAddEditVM model)
        {
            Toy toy = await _toyRepository.GetToyDetails(model.Id.HasValue ? model.Id.Value : throw new Exception("Missing id value"));
            toy.Name = model.Name;
            toy.ToyType = model.ToyType.HasValue ? model.ToyType.Value : ToyType.Figure;
            toy.BrandId = model.BrandId;
            return await _toyRepository.EditToy(toy);
        }

        public async Task<int> DeleteToy(int id)
        {
            Toy toy = await _toyRepository.GetToyDetails(id);
            return await _toyRepository.DeleteToy(toy);
        }

        public Dictionary<ToyType, string> GetToyTypesToSelectList()
        {
            return Enum.GetValues(typeof(ToyType))
                .Cast<ToyType>()
                .ToDictionary(x => x, x => x.ToString());
        }
    }
}
