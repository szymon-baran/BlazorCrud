using BlazorCrud.Server.Application.Abstraction;
using BlazorCrud.Server.Data.Abstraction;
using BlazorCrud.Shared.Dictionaries;
using BlazorCrud.Shared.Domain;

namespace BlazorCrud.Server.Application.Services
{
    public class BrandService : IBrandService
    {
        #region Dependencies

        private readonly IBrandRepository _brandRepository;

        public BrandService(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        #endregion


        public Dictionary<int, string> GetBrandsToSelectList()
        {
            return _brandRepository.GetBrandsToSelectList();
        }
    }
}
