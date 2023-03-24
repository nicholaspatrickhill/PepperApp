using Microsoft.AspNetCore.Mvc;
using PepperApp.DataTransferObject;
using PepperApp.Services;

namespace PepperApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PepperController : ControllerBase
    {
        private readonly IPepperService _pepperService;

        public PepperController(IPepperService pepperService)
        {
            _pepperService = pepperService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllPeppers()
        {
            var peppers = await _pepperService.GetAllPeppersServiceAsync();
            return Ok(peppers);
        }

        [HttpGet("mild")]
        public async Task<IActionResult> GetMildPeppers()
        {
            var peppers = await _pepperService.GetMildPeppersServiceAsync();
            return Ok(peppers);
        }

        [HttpGet("medium")]
        public async Task<IActionResult> GetMediumPeppers()
        {
            var peppers = await _pepperService.GetMediumPeppersServiceAsync();
            return Ok(peppers);
        }

        [HttpGet("mediumhot")]
        public async Task<IActionResult> GetMediumHotPeppers()
        {
            var peppers = await _pepperService.GetMediumHotPeppersServiceAsync();
            return Ok(peppers);
        }

        [HttpGet("hot")]
        public async Task<IActionResult> GetHotPeppers()
        {
            var peppers = await _pepperService.GetHotPeppersServiceAsync();
            return Ok(peppers);
        }

        [HttpGet("superhot")]
        public async Task<IActionResult> GetSuperHotPeppers()
        {
            var peppers = await _pepperService.GetSuperHotPeppersServiceAsync();
            return Ok(peppers);
        }

        [HttpGet("{pepperName}")]
        public async Task<IActionResult> GetPepperByName(string pepperName)
        {
            var pepper = await _pepperService.GetPepperByNameServiceAsync(pepperName);
            if (pepper == null)
            {
                return NotFound();
            }
            return Ok(pepper);
        }

        [HttpPost]
        public async Task<IActionResult> AddPepper([FromBody] PepperDto pepperDto)
        {
            try
            {
                await _pepperService.CreatePepperServiceAsync(pepperDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{pepperName}")]
        public async Task<IActionResult> UpdatePepper(string pepperName, [FromBody] PepperDto pepperToUpdate)
        {
            try
            {
                await _pepperService.UpdatePepperServiceAsync(pepperToUpdate);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{pepperName}")]
        public async Task<IActionResult> RemovePepper(string pepperName)
        {
            try
            {
                var pepperToRemove = await _pepperService.GetPepperByNameServiceAsync(pepperName);

                await _pepperService.RemovePepperServiceAsync(pepperToRemove!);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}