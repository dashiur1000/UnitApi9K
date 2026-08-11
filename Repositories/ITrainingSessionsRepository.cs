using UnitApi9K.DTOs;

namespace UnitApi9K.Repositories
{
    public interface ITrainingSessionsRepository
    {
        Task<TrainingDto> CreateTrainingAsync(CreateTrainingDto trainingDto);
    }
}
