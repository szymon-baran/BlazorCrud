using BlazorCrud.Client.Abstraction;
using BlazorCrud.Server.Application;
using BlazorCrud.Shared.Dictionaries;
using BlazorCrud.Shared.Domain;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorCrud.Client.Services
{
    public class ToyService : IToyService
    {
        private readonly HttpClient _httpClient;
        private readonly string _api = "api/toy";
        private readonly NavigationManager _navigationManager;

        public ToyService(HttpClient httpClient, NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _navigationManager = navigationManager;
        }

        public List<Toy> Toys { get; set; } = new();
        public Dictionary<ToyType, string> ToyTypesToSelectList { get; set; } = new();
        public ToyAddEditVM Toy { get; set; }
        public ToyAddEditVM AddModel { get; set; }

        public async Task GetToysList()
        {
            List<Toy>? toys = await _httpClient.GetFromJsonAsync<List<Toy>>(_api);
            if (toys != null)
                Toys = toys;
        }

        public async Task AddToy(ToyAddEditVM model)
        {
            var result = await _httpClient.PostAsJsonAsync(_api, model);
            var response = await result.Content.ReadFromJsonAsync<ToyAddEditVM>();
            Toy = response;
            await GetToysList();
            _navigationManager.NavigateTo("toys");
        }

        public async Task<ToyAddEditVM> GetToyDetails(int id)
        {
            ToyAddEditVM? toy = await _httpClient.GetFromJsonAsync<ToyAddEditVM>($"{_api}/{id}");
            if (toy != null)
                return toy;
            throw new Exception("Not found");
        }

        public async Task EditToy(ToyAddEditVM model)
        {
            var result = await _httpClient.PutAsJsonAsync(_api, model);
            var response = await result.Content.ReadFromJsonAsync<ToyAddEditVM>();
            Toy = response;
            await GetToysList();
            _navigationManager.NavigateTo("toys");
        }

        public async Task DeleteToy(int id)
        {
            var result = await _httpClient.DeleteAsync($"{_api}/{id}");
            var response = await result.Content.ReadFromJsonAsync<int>();
            await GetToysList();
            _navigationManager.NavigateTo("toys");
        }

        public async Task GetToyTypesToSelectList()
        {
            Dictionary<ToyType, string>? toyTypes = await _httpClient.GetFromJsonAsync<Dictionary<ToyType, string>>($"{_api}/getToyTypesToSelectList");
            if (toyTypes != null)
                ToyTypesToSelectList = toyTypes;
        }

    }
}
