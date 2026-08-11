using System.ComponentModel.DataAnnotations;

namespace UnitApi9K.DTOs
{
    public class TrainingWithDogAndHandlerDto
    {
        public int TrainingId { get; set; }
        public DateTime SessionDate { get; set; }
        public int DurationMinutes { get; set; }
        public string TrainingType { get; set; }
        public int PerformanceScore { get; set; }
        public string DogName { get; set; }
        public string Specialty {  get; set; }
        public string? HandlerFullName { get; set; }
    }
}
