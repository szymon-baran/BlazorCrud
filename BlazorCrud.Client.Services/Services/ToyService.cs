using BlazorCrud.Client.Abstraction;
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

        public Task<Toy> GetToyDetails(int id)
        {
            throw new NotImplementedException();
        }

        public async Task GetToysList()
        {
            List<Toy>? toys = await _httpClient.GetFromJsonAsync<List<Toy>>("api/toy");
            if (toys != null)
                Toys = toys;
        }
    }
}
