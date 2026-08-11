using System.ComponentModel.DataAnnotations;

namespace UnitApi9K.DTOs
{
    public class CreateTrainingDto
    {
        [Required]
        public int DogId { get; set; }
        [Required]
        public DateTime SessionDate { get; set; }
        [Required]
        [Range(1, 300)]
        public int DurationMinutes { get; set; }
        [Required]
        [RegularExpression(@"^(Obedience|ScentDetection|Agility|FieldExercise|Endurance)$")]//
        public string TrainingType { get; set; }
        [Required]
        [Range(0, 100)]
        public int PerformanceScore { get; set; }
        [Required]
        [StringLength(100)]
        public string Evaluator { get; set; }
    }
}
