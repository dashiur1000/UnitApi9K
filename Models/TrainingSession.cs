using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
namespace UnitApi9K.Models
{
    public class TrainingSession
    {
        public int Id { get; set; }
        [Required]
        //[DateTimeConstant(< DateTime.UtcNow)]//
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
        public bool Passed { get; set; }
        [Required]
        [StringLength(100)]
        public string Evaluator {  get; set; }
        public Dog? Dog { get; set; }
        public int DogId { get; set; }
    }
}
