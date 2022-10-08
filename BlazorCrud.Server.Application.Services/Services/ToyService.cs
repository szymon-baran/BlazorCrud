using BlazorCrud.Server.Application.Abstraction;
using BlazorCrud.Server.Data.Abstraction;
using BlazorCrud.Shared.Dictionaries;
using BlazorCrud.Shared.Domain;

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


        public Toy GetToyDetails(int id)
        {
            return _toyRepository.GetToyDetails(id);
        }

        public List<Toy> GetToysList()
        {
            return _toyRepository.GetToysList();
        }

        public Dictionary<ToyType, string> GetToyTypesToSelectList()
        {
            return Enum.GetValues(typeof(ToyType))
                .Cast<ToyType>()
                .ToDictionary(x => x, x => x.ToString());
        }
    }
}
