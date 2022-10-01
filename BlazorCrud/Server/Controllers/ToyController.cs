using BlazorCrud.Shared.Dictionaries;
using BlazorCrud.Shared.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace BlazorCrud.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToyController : ControllerBase
    {
        public static List<Brand> brands = new()
        {
            new Brand() { Id = 1, Name = "LEGO" },
            new Brand() { Id = 2, Name = "Hot Wheels" },
            new Brand() { Id = 3, Name = "Funko" },
            new Brand() { Id = 4, Name = "Marvel" }
        };

        public static List<Toy> toys = new()
        {
            new Toy() { Id = 1, Name = "Star Wars Star Destroyer", ToyType = ToyType.Bricks, Brand = brands[0] },
            new Toy() { Id = 2, Name = "Pop Cyberpunk 2077 - Johnny Silverhand", ToyType = ToyType.Figure, Brand = brands[2] },
            new Toy() { Id = 3, Name = "Honda Civic Type S", ToyType = ToyType.Figure, Brand = brands[1] },
            new Toy() { Id = 4, Name = "Spiderman - The Game (PS5)", ToyType = ToyType.Game, Brand = brands[3] },
            new Toy() { Id = 5, Name = "Iron Man Action Figure", ToyType = ToyType.Figure, Brand = brands[3] },
            new Toy() { Id = 6, Name = "Hulk Action Figure", ToyType = ToyType.Figure, Brand = brands[3] }
        };

        [HttpGet]
        public async Task<ActionResult<List<Toy>>> GetToysList()
        {
            return Ok(toys);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Toy>> GetToyDetails(int id)
        {
            Toy toy = toys.FirstOrDefault(x => x.Id == id) ?? throw new Exception("No toy");
            return Ok(toy);
        }
    }
}
