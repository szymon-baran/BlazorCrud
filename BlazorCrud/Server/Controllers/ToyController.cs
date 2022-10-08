using BlazorCrud.Server.Application.Abstraction;
using BlazorCrud.Shared.Dictionaries;
using BlazorCrud.Shared.Domain;
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
        private readonly IToyService _toyService;
        private readonly IBrandService _brandService;

        public ToyController(IToyService toyService,
                             IBrandService brandService)
        {
            _toyService = toyService;
            _brandService = brandService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Toy>>> GetToysList()
        {
            return Ok(_toyService.GetToysList());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Toy>> GetToyDetails(int id)
        {
            return Ok(_toyService.GetToyDetails(id));
        }

        [HttpGet("getBrandsToSelectList")]
        public async Task<ActionResult<Dictionary<int, string>>> GetBrandsToSelectList()
        {
            return Ok(_brandService.GetBrandsToSelectList());
        }

        [HttpGet("getToyTypesToSelectList")]
        public async Task<ActionResult<Dictionary<ToyType, string>>> GetToyTypesToSelectList()
        {
            return Ok(_toyService.GetToyTypesToSelectList());
        }
    }
}
