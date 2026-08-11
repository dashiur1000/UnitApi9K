using System.ComponentModel.DataAnnotations;

namespace UnitApi9K.DTOs
{
    public class DogDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        public string MicrochipId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Specialty { get; set; }
        public string Status { get; set; } = "InTraining";
    }
}
