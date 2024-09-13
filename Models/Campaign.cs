using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace AnallyzerAPI.Models
{
    [Table("TB_CAMPAINS")]
    public class Campain
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [Column("dt_names")]
        public string Name { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória.")]
        [Column("dt_descriptions")]
        public string Description { get; set; }

        [Required(ErrorMessage = "A empresa é obrigatória.")]
        [Column("dt_companies")]
        public string Company { get; set; }

        [Required(ErrorMessage = "A data de início é obrigatória.")]
        [Column("dt_startdate")]
        public DateTime StartDate { get; set; } = DateTime.UtcNow;

        [Required(ErrorMessage = "A data de previsão de término é obrigatória.")]
        [Column("dt_forecastdate")]
        public DateTime ForecastDate { get; set; } = DateTime.UtcNow;

        [Required(ErrorMessage = "O status é obrigatório.")]
        [Column("dt_status")]
        public string Status { get; set; } = "True";


        [Required(ErrorMessage = "A data é obrigatória.")]
        [Column("dt_registrationdate")]
        public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;


    }
}