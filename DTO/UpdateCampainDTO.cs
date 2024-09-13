using System;
using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace AnallyzerAPI.DTO
{
    /// <summary>
    /// DTO usado para atualizar campanhas existentes.
    /// </summary>
    public class UpdateCampainDTO
    {
        /// <summary>
        /// Nome da campanha.
        /// </summary>
        [SwaggerSchema(Description = "O novo nome da campanha. Este campo é opcional.")]
        public string? Name { get; set; }

        /// <summary>
        /// Descrição da campanha.
        /// </summary>
        [SwaggerSchema(Description = "Uma nova descrição para a campanha. Este campo é opcional.")]
        public string? Description { get; set; }

        /// <summary>
        /// Empresa responsável pela campanha.
        /// </summary>
        [SwaggerSchema(Description = "A nova empresa responsável pela campanha. Este campo é opcional.")]
        public string? Company { get; set; }

        /// <summary>
        /// Data de início da campanha.
        /// </summary>
        [SwaggerSchema(Description = "A nova data e hora de início da campanha. Este campo é opcional.")]
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Data prevista para o término da campanha.
        /// </summary>
        [SwaggerSchema(Description = "A nova data e hora previstas para o término da campanha. Este campo é opcional.")]
        public DateTime? ForecastDate { get; set; }

        /// <summary>
        /// Status atual da campanha.
        /// </summary>
        [SwaggerSchema(Description = "O novo status da campanha. Este campo é opcional.")]
        public string? Status { get; set; }
    }
}
