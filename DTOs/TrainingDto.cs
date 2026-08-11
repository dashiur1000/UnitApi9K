using System.ComponentModel.DataAnnotations;

namespace UnitApi9K.DTOs
{
    public class TrainingDto
    {
        public int DogId { get; set; }
        public int TrainingId { get; set; }
        public DateTime SessionDate { get; set; }
        public int DurationMinutes { get; set; }
        public string TrainingType { get; set; }
        public int PerformanceScore { get; set; }
        public bool Passed { get; set; }
        public string Evaluator { get; set; }
    }
}
