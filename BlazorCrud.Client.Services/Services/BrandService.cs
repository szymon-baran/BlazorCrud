using BlazorCrud.Client.Abstraction;
using BlazorCrud.Shared.Domain;
using System.Collections.Generic;
using System.Net.Http.Json;

namespace BlazorCrud.Client.Services
{
    public class BrandService : IBrandService
    {
        private readonly HttpClient _httpClient;

        public BrandService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Dictionary<int, string> BrandsToSelectList { get; set; } = new();
        public async Task GetBrandsToSelectList()
        {
            Dictionary<int, string>? brands = await _httpClient.GetFromJsonAsync<Dictionary<int, string>>("api/toy/getBrandsToSelectList");
            if (brands != null)
                BrandsToSelectList = brands;
        }
    }
}
