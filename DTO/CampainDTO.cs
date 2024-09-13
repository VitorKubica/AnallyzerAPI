using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnallyzerAPI.DTO
{
    public class CampainDTO
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "A empresa é obrigatória.")]
        [Column("dt_companies")]
        public string Company { get; set; }

        [Required(ErrorMessage = "A data de início é obrigatória.")]
        public DateTime StartDate { get; set; } = DateTime.UtcNow;

        [Required(ErrorMessage = "A data de previsão de término é obrigatória.")]
        public DateTime ForecastDate { get; set; } = DateTime.UtcNow;

    }
}
