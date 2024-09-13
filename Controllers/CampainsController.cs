using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AnallyzerAPI.Models;
using AnallyzerAPI.Services;
using AnallyzerAPI.DTO;

namespace AnallyzerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampainsController : ControllerBase
    {
        private readonly ICampaignService _campaignService;

        public CampainsController(ICampaignService campaignService)
        {
            _campaignService = campaignService;
        }

        // GET: api/Campains
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Campain>>> GetAllCampains()
        {
            var campains = await _campaignService.GetAllCampaignsAsync();
            return Ok(campains);
        }

        // GET: api/Campains/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Campain>> GetCampain(int id)
        {
            var campain = await _campaignService.GetCampaignByIdAsync(id);

            if (campain == null)
            {
                return NotFound();
            }

            return Ok(campain);
        }

        // POST: api/Campains
        [HttpPost]
        public async Task<ActionResult<Campain>> PostCampain(CampainDTO campainDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Convertendo o DTO para a entidade Campain
            var campain = new Campain
            {
                Name = campainDto.Name,
                Description = campainDto.Description,
                Company = campainDto.Company,
                StartDate = campainDto.StartDate,
                ForecastDate = campainDto.ForecastDate,
                RegistrationDate = DateTime.UtcNow // Define a data de registro como a data atual
            };

            var createdCampain = await _campaignService.CreateCampaignAsync(campain);
            return CreatedAtAction(nameof(GetCampain), new { id = createdCampain.ID }, createdCampain);
        }


        // PUT: api/Campains/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCampain(int id, UpdateCampainDTO campainDto)
        {
            var existingCampain = await _campaignService.GetCampaignByIdAsync(id);

            if (existingCampain == null)
            {
                return NotFound();
            }

            // Atualizar apenas os campos que não forem nulos no DTO
            if (!string.IsNullOrEmpty(campainDto.Name))
            {
                existingCampain.Name = campainDto.Name;
            }

            if (!string.IsNullOrEmpty(campainDto.Description))
            {
                existingCampain.Description = campainDto.Description;
            }

            if (!string.IsNullOrEmpty(campainDto.Company))
            {
                existingCampain.Company = campainDto.Company;
            }

            if (campainDto.StartDate.HasValue)
            {
                existingCampain.StartDate = campainDto.StartDate.Value;
            }

            if (campainDto.ForecastDate.HasValue)
            {
                existingCampain.ForecastDate = campainDto.ForecastDate.Value;
            }

            if (!string.IsNullOrEmpty(campainDto.Status))
            {
                existingCampain.Status = campainDto.Status;
            }

            var success = await _campaignService.UpdateCampaignAsync(id, existingCampain);

            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }



        // DELETE: api/Campains/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCampain(int id)
        {
            var success = await _campaignService.DeleteCampaignAsync(id);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
