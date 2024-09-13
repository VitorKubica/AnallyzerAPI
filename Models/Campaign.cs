using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Swashbuckle.AspNetCore.Annotations;

namespace AnallyzerAPI.Models
{
    /// <summary>
    /// Representa uma campanha no sistema.
    /// </summary>
    [Table("TB_CAMPAINS")]
    public class Campain
    {
        /// <summary>
        /// Identificador único da campanha.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [SwaggerSchema(Description = "O identificador único da campanha, gerado automaticamente pelo banco de dados.")]
        public int ID { get; set; }

        /// <summary>
        /// Nome da campanha.
        /// </summary>
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [Column("dt_names")]
        [SwaggerSchema(Description = "O nome da campanha.")]
        public string Name { get; set; }

        /// <summary>
        /// Descrição da campanha.
        /// </summary>
        [Required(ErrorMessage = "A descrição é obrigatória.")]
        [Column("dt_descriptions")]
        [SwaggerSchema(Description = "Uma descrição detalhada da campanha.")]
        public string Description { get; set; }

        /// <summary>
        /// Empresa responsável pela campanha.
        /// </summary>
        [Required(ErrorMessage = "A empresa é obrigatória.")]
        [Column("dt_companies")]
        [SwaggerSchema(Description = "O nome da empresa responsável pela campanha.")]
        public string Company { get; set; }

        /// <summary>
        /// Data de início da campanha.
        /// </summary>
        [Required(ErrorMessage = "A data de início é obrigatória.")]
        [Column("dt_startdate")]
        [SwaggerSchema(Description = "A data e hora em que a campanha começa.")]
        public DateTime StartDate { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Data prevista para o término da campanha.
        /// </summary>
        [Required(ErrorMessage = "A data de previsão de término é obrigatória.")]
        [Column("dt_forecastdate")]
        [SwaggerSchema(Description = "A data e hora previstas para o término da campanha.")]
        public DateTime ForecastDate { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Status atual da campanha.
        /// </summary>
        [Required(ErrorMessage = "O status é obrigatório.")]
        [Column("dt_status")]
        [SwaggerSchema(Description = "O status atual da campanha, por exemplo, 'Ativa' ou 'Inativa'.")]
        public string Status { get; set; } = "True";

        /// <summary>
        /// Data em que a campanha foi registrada.
        /// </summary>
        [Required(ErrorMessage = "A data de registro é obrigatória.")]
        [Column("dt_registrationdate")]
        [SwaggerSchema(Description = "A data e hora em que a campanha foi registrada no sistema.")]
        public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;
    }
}
