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
            var pepperResponses = peppers.Select(p => new PepperResponse
            {
                PepperName = p.PepperName,
                PepperScovilleUnitMinimum = p.PepperScovilleUnitMinimum,
                PepperScovilleUnitMaximum = p.PepperScovilleUnitMaximum
            });
            return Ok(pepperResponses);
        }

        [HttpGet("mild")]
        public async Task<IActionResult> GetMildPeppers()
        {
            var peppers = await _pepperService.GetMildPeppersServiceAsync();
            var mildPepperResponses = peppers.Select(p => new PepperResponse
            {
                PepperName = p.PepperName,
                PepperScovilleUnitMinimum = p.PepperScovilleUnitMinimum,
                PepperScovilleUnitMaximum = p.PepperScovilleUnitMaximum

            });

            return Ok(mildPepperResponses);
        }

        [HttpGet("medium")]
        public async Task<IActionResult> GetMediumPeppers()
        {
            var peppers = await _pepperService.GetMediumPeppersServiceAsync();
            var mediumPepperResponses = peppers.Select(p => new PepperResponse
            {
                PepperName = p.PepperName,
                PepperScovilleUnitMinimum = p.PepperScovilleUnitMinimum,
                PepperScovilleUnitMaximum = p.PepperScovilleUnitMaximum

            });

            return Ok(mediumPepperResponses);
        }

        [HttpGet("mediumhot")]
        public async Task<IActionResult> GetMediumHotPeppers()
        {
            var peppers = await _pepperService.GetMediumHotPeppersServiceAsync();
            var mediumHotPepperResponses = peppers.Select(p => new PepperResponse
            {
                PepperName = p.PepperName,
                PepperScovilleUnitMinimum = p.PepperScovilleUnitMinimum,
                PepperScovilleUnitMaximum = p.PepperScovilleUnitMaximum

            });

            return Ok(mediumHotPepperResponses);
        }

        [HttpGet("hot")]
        public async Task<IActionResult> GetHotPeppers()
        {
            var peppers = await _pepperService.GetHotPeppersServiceAsync();
            var hotPepperResponses = peppers.Select(p => new PepperResponse
            {
                PepperName = p.PepperName,
                PepperScovilleUnitMinimum = p.PepperScovilleUnitMinimum,
                PepperScovilleUnitMaximum = p.PepperScovilleUnitMaximum

            });

            return Ok(hotPepperResponses);
        }

        [HttpGet("superhot")]
        public async Task<IActionResult> GetSuperHotPeppers()
        {
            var peppers = await _pepperService.GetSuperHotPeppersServiceAsync();
            var hotPepperResponses = peppers.Select(p => new PepperResponse
            {
                PepperName = p.PepperName,
                PepperScovilleUnitMinimum = p.PepperScovilleUnitMinimum,
                PepperScovilleUnitMaximum = p.PepperScovilleUnitMaximum

            });

            return Ok(hotPepperResponses);
        }

        [HttpGet("{pepperName}")]
        public async Task<IActionResult> GetPepperByName(string pepperName)
        {
            var pepper = await _pepperService.GetPepperByNameServiceAsync(pepperName);
            var pepperResponse = new PepperResponse
            {
                PepperName = pepper!.PepperName,
                PepperScovilleUnitMinimum = pepper.PepperScovilleUnitMinimum,
                PepperScovilleUnitMaximum = pepper.PepperScovilleUnitMaximum
            };

            if (pepper == null)
            {
                return NotFound();
            }

            return Ok(pepperResponse);
        }

        [HttpPost]
        public async Task<IActionResult> AddPepper([FromBody] PepperRequest pepperRequest)
        {
            try
            {
                var pepperDto = new PepperDto
                {
                    PepperName = pepperRequest.PepperName,
                    PepperScovilleUnitMinimum = pepperRequest.PepperScovilleUnitMinimum,
                    PepperScovilleUnitMaximum = pepperRequest.PepperScovilleUnitMaximum,
                    IsReadOnly = false
                };

                await _pepperService.CreatePepperServiceAsync(pepperDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{pepperName}")]
        public async Task<IActionResult> UpdatePepper(string pepperName, [FromBody] PepperRequest pepperRequest)
        {
            try
            {
                var pepperToUpdate = await _pepperService.GetPepperByNameServiceAsync(pepperName);

                if (pepperToUpdate!.IsReadOnly)
                {
                    return BadRequest("That pepper is read-only and cannot be updated.");
                }

                pepperToUpdate.PepperName = pepperRequest.PepperName;
                pepperToUpdate.PepperScovilleUnitMinimum = pepperRequest.PepperScovilleUnitMinimum;
                pepperToUpdate.PepperScovilleUnitMaximum = pepperRequest.PepperScovilleUnitMaximum;

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