using UnitApi9K.DTOs;
using UnitApi9K.Models;

namespace UnitApi9K.Repositories
{
    public interface ITrainingSessionsRepository
    {
        Task<ICollection<CreateTrainingDto>> GetTrainingByIdAsync(int id);
        Task<TrainingDto> CreateTrainingAsync(CreateTrainingDto trainingDto);
        Task<ICollection<TrainingWithDogAndHandlerDto>> GetAllDetailedAsync();
        Task<TrainingSessionPagedDto> GetPagedAsync(int page, int pageSize);
    }
}
