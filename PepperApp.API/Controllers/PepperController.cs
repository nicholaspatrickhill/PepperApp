using Microsoft.AspNetCore.Mvc;
using PepperApp.Entities;
using PepperApp.Services;

namespace PepperApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PepperController : ControllerBase
    {
        private readonly IPepperService _pepperService;

        public PepperController(IPepperService pepperService)
        {
            _pepperService = pepperService;
        }

        [HttpGet("{pepperName}")]
        public async Task<ActionResult<Pepper>> GetPepperByName(string pepperName)
        {
            var result = await _pepperService.GetPepperByNameServiceAsync(pepperName);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddPepper([FromBody] Pepper pepperToAdd)
        {
            await _pepperService.AddPepperServiceAsync(pepperToAdd.PepperName, pepperToAdd.PepperScovilleUnitMinimum, pepperToAdd.PepperScovilleUnitMaximum);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<List<Pepper>>> GetAllPeppers()
        {
            var result = await _pepperService.GetAllPeppersServiceAsync();
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> RemovePepper([FromBody] Pepper pepperToRemove)
        {
            await _pepperService.RemovePepperServiceAsync(pepperToRemove);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePepper([FromBody] Pepper updatedPepper)
        {
            await _pepperService.UpdatePepperServiceAsync(updatedPepper);
            return Ok();
        }

        [HttpGet("mild")]
        public async Task<ActionResult<List<Pepper>>> GetMildPeppers()
        {
            var result = await _pepperService.GetMildPeppersServiceAsync();
            return Ok(result);
        }

        [HttpGet("medium")]
        public async Task<ActionResult<List<Pepper>>> GetMediumPeppers()
        {
            var result = await _pepperService.GetMediumPeppersServiceAsync();
            return Ok(result);
        }

        [HttpGet("medium-hot")]
        public async Task<ActionResult<List<Pepper>>> GetMediumHotPeppers()
        {
            var result = await _pepperService.GetMediumHotPeppersServiceAsync();
            return Ok(result);
        }

        [HttpGet("hot")]
        public async Task<ActionResult<List<Pepper>>> GetHotPeppers()
        {
            var result = await _pepperService.GetHotPeppersServiceAsync();
            return Ok(result);
        }

        [HttpGet("super-hot")]
        public async Task<ActionResult<List<Pepper>>> GetSuperHotPeppers()
        {
            var result = await _pepperService.GetSuperHotPeppersServiceAsync();
            return Ok(result);
        }
    }
}
