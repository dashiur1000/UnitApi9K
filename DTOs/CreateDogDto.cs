using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace UnitApi9K.DTOs
{
    [Index(nameof(MicrochipId), IsUnique = true)]
    public class CreateDogDto
    {
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
        public DateTime DateOfBirth { get; set; }
        [Required]
        [RegularExpression(@"^(ExplosiveDetection|NarcoticsDetection|Tracking|Attack|Search)$")]//
        public string Specialty { get; set; }
        [Required]

        [RegularExpression(@"^(Active|InTraining|Retired)$")]//
        public string Status { get; set; } = "InTraining";
    }
}
