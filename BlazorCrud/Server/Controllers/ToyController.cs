using BlazorCrud.Server.Application;
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

        [HttpPost]
        public async Task<ActionResult<Toy>> AddToy(ToyAddEditVM model)
        {
            return Ok(await _toyService.AddToy(model));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ToyAddEditVM>> GetToyDetails(int id)
        {
            return Ok(await _toyService.GetToyDetailsVM(id));
        }

        [HttpPut]
        public async Task<ActionResult<Toy>> EditToy(ToyAddEditVM model)
        {
            return Ok(await _toyService.EditToy(model));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeleteToy(int id)
        {
            return Ok(await _toyService.DeleteToy(id));
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
