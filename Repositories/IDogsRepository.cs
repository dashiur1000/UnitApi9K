using UnitApi9K.DTOs;

namespace UnitApi9K.Repositories
{
    public interface IDogsRepository
    {
        Task<ICollection<DogDto>> GetDogByIdAsync(int id);
        Task<DogDto> CreateDogAsync(CreateDogDto Dog);
        Task<ICollection<DogDto>> GetDogsByFilters(string? specialty, string? status);
        Task<ICollection<DogWithHandlerDto>> GetDogWithHandlerAsync();

    }
}
