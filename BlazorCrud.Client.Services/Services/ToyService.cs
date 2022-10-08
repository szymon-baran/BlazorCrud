using BlazorCrud.Client.Abstraction;
using BlazorCrud.Shared.Dictionaries;
using BlazorCrud.Shared.Domain;
using System.Net.Http.Json;

namespace BlazorCrud.Client.Services
{
    public class ToyService : IToyService
    {
        private readonly HttpClient _httpClient;

        public ToyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<Toy> Toys { get; set; } = new ();
        public Dictionary<ToyType, string> ToyTypesToSelectList { get; set; } = new ();


        public async Task GetToysList()
        {
            List<Toy>? toys = await _httpClient.GetFromJsonAsync<List<Toy>>("api/toy");
            if (toys != null)
                Toys = toys;
        }

        public async Task GetToyTypesToSelectList()
        {
            Dictionary<ToyType, string>? toyTypes = await _httpClient.GetFromJsonAsync<Dictionary<ToyType, string>>("api/toy/getToyTypesToSelectList");
            if (toyTypes != null)
                ToyTypesToSelectList = toyTypes;
        }

        public async Task<Toy> GetToyDetails(int id)
        {
            Toy? toy = await _httpClient.GetFromJsonAsync<Toy>($"api/toy/{id}");
            if (toy != null)
                return toy;
            throw new Exception("Not found");
        }

    }
}
