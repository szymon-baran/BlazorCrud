using BlazorCrud.Shared.Dictionaries.Enums;
using BlazorCrud.Shared.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace BlazorCrud.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToyController : ControllerBase
    {
        //[HttpGet]
        //public async Task<ActionResult<List<Toy>>> GetToysList()
        //{
        //    return Ok(toys);
        //}

        //[HttpGet("{id}")]
        //public async Task<ActionResult<Toy>> GetToyDetails(int id)
        //{
        //    Toy toy = toys.FirstOrDefault(x => x.Id == id) ?? throw new Exception("No toy");
        //    return Ok(toy);
        //}

        //[HttpGet("getBrandsToSelectList")]
        //public async Task<Dictionary<int, string>> GetBrandsToSelectList()
        //{
        //    return brands.ToDictionary(x => x.Id, x => x.Name);
        //}

        [HttpGet("getToyTypesToSelectList")]
        public async Task<Dictionary<ToyType, string>> GetToyTypesToSelectList()
        {
            return Enum.GetValues(typeof(ToyType))
                .Cast<ToyType>()
                .ToDictionary(x => x, x => x.ToString());
        }
    }
}
