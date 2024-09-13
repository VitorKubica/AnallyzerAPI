using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnallyzerAPI.DTO
{
    /// <summary>
    /// DTO usado para criar e atualizar campanhas.
    /// </summary>
    public class CampainDTO
    {
        /// <summary>
        /// Nome da campanha.
        /// </summary>
        [Required(ErrorMessage = "Não se esqueça de incluir o nome da campanha.")]
        [SwaggerSchema(Description = "O nome atribuído à campanha.")]
        public string Name { get; set; }

        /// <summary>
        /// Descrição da campanha.
        /// </summary>
        [Required(ErrorMessage = "A descrição é fundamental para entendermos a campanha.")]
        [SwaggerSchema(Description = "Uma breve descrição da campanha, explicando o que está sendo oferecido.")]
        public string Description { get; set; }

        /// <summary>
        /// Empresa responsável pela campanha.
        /// </summary>
        [Required(ErrorMessage = "Precisamos saber qual empresa está promovendo a campanha.")]
        [Column("dt_companies")]
        [SwaggerSchema(Description = "A empresa que está promovendo a campanha.")]
        public string Company { get; set; }

        /// <summary>
        /// Data de início da campanha.
        /// </summary>
        [Required(ErrorMessage = "Defina a data de início para sabermos quando a campanha começa.")]
        [SwaggerSchema(Description = "A data e hora de início da campanha.")]
        public DateTime StartDate { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Data prevista para o término da campanha.
        /// </summary>
        [Required(ErrorMessage = "A data de término é importante para planejarmos os próximos passos.")]
        [SwaggerSchema(Description = "A data e hora previstas para o término da campanha.")]
        public DateTime ForecastDate { get; set; } = DateTime.UtcNow;
    }
}
