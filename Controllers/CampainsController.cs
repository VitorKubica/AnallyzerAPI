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

        /// <summary>
        /// Recupera todas as campanhas.
        /// </summary>
        /// <returns>Uma lista de campanhas.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Campain>), 200)]
        public async Task<ActionResult<IEnumerable<Campain>>> GetAllCampains()
        {
            var campains = await _campaignService.GetAllCampaignsAsync();
            return Ok(campains);
        }

        /// <summary>
        /// Recupera uma campanha específica pelo ID.
        /// </summary>
        /// <param name="id">O ID da campanha.</param>
        /// <returns>A campanha correspondente ao ID fornecido.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Campain), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Campain>> GetCampain(int id)
        {
            var campain = await _campaignService.GetCampaignByIdAsync(id);

            if (campain == null)
            {
                return NotFound();
            }

            return Ok(campain);
        }

        /// <summary>
        /// Cria uma nova campanha.
        /// </summary>
        /// <param name="campainDto">Os dados da nova campanha.</param>
        /// <returns>A campanha criada.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(Campain), 201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Campain>> PostCampain(CampainDTO campainDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var campain = new Campain
            {
                Name = campainDto.Name,
                Description = campainDto.Description,
                Company = campainDto.Company,
                StartDate = campainDto.StartDate,
                ForecastDate = campainDto.ForecastDate,
                RegistrationDate = DateTime.UtcNow
            };

            var createdCampain = await _campaignService.CreateCampaignAsync(campain);
            return CreatedAtAction(nameof(GetCampain), new { id = createdCampain.ID }, createdCampain);
        }

        /// <summary>
        /// Atualiza uma campanha existente pelo ID.
        /// </summary>
        /// <param name="id">O ID da campanha a ser atualizada.</param>
        /// <param name="campainDto">Os dados atualizados da campanha.</param>
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> PutCampain(int id, UpdateCampainDTO campainDto)
        {
            var existingCampain = await _campaignService.GetCampaignByIdAsync(id);

            if (existingCampain == null)
            {
                return NotFound();
            }

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

        /// <summary>
        /// Remove uma campanha pelo ID.
        /// </summary>
        /// <param name="id">O ID da campanha a ser removida.</param>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
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
