using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace UnitApi9K.Models
{
    [Index(nameof(MicrochipId), IsUnique = true)]
    public class Dog
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Breed { get; set; }
        [Required]
        [StringLength(15)]
        public string MicrochipId { get; set; }
        [Required]
        //[DateTimeConstant(< DateTime.UtcNow)]//
        public DateTime DateOfBirth { get; set; }
        [Required]
        [RegularExpression(@"^(ExplosiveDetection|NarcoticsDetection|Tracking|Attack|Search)$")]//
        public string Specialty { get; set; }
        [Required]

        [RegularExpression(@"^(Active|InTraining|Retired)$")]//
        public string Status { get; set; } = "InTraining";
        public int? HandlerId { get; set; }
        public Handler? Handler { get; set; }
        public ICollection<TrainingSession>? TrainingSession { get; set; }
    }
}
