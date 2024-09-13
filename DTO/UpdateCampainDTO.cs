namespace AnallyzerAPI.DTO
{
    public class UpdateCampainDTO
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Company { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? ForecastDate { get; set; }
        public string? Status { get; set; }
    }
}
