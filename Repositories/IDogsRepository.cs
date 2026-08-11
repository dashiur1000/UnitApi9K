using UnitApi9K.DTOs;

namespace UnitApi9K.Repositories
{
    public interface IDogsRepository
    {
        Task<ICollection<DogDto>> GetDogByIdAsync(int id);
        Task<DogDto> CreateDogAsync(CreateDogDto Dog);
    }
}
