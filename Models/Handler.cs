using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace UnitApi9K.Models
{
    [Index(nameof(PersonalNumber), IsUnique = true)]
    public class Handler
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string FullName { get; set; }
        [Required]
        [StringLength(10)]
        public string PersonalNumber { get; set; }
        [Required]
        [StringLength(30)]
        public string Rank { get; set; }
        [Required]
        [Range(0, 100)]
        public int YearsOfExperience { get; set; }
        [Required]
        [StringLength(100)]
        public string BaseAssigned { get; set; }
        public Dog? Dog { get; set; }
    }
}
