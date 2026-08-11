using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders.Physical;
using System.Collections;
using UnitApi9K.Data;
using UnitApi9K.DTOs;
using UnitApi9K.Models;


namespace UnitApi9K.Repositories
{
    public class TrainingSessionsRepository : ITrainingSessionsRepository
    {
        private readonly UnitManagementDbContext _context;
        public TrainingSessionsRepository(UnitManagementDbContext context)
        {
            _context = context;
        }
        public async Task<TrainingDto> CreateTrainingAsync(CreateTrainingDto trainingDto)
        {
            try
            {
                bool Passed = false;
                if (trainingDto.PerformanceScore >= 75)
                {
                    Passed = true;
                }
                var dog = await _context.Dogs.Where(d => d.Id == trainingDto.DogId).Select(a => new DogDto
                {
                    Id = a.Id,
                    Name = a.Name,
                    DateOfBirth = a.DateOfBirth,
                    Breed = a.Breed,
                    MicrochipId = a.MicrochipId,
                    Specialty = a.Specialty,
                    Status = a.Status,
                }).ToListAsync();
                if(dog == null || dog.Count == 0)
                {
                    return null;
                }
                var newTraining = new TrainingSession
                {
                    DogId = trainingDto.DogId,
                    SessionDate = trainingDto.SessionDate,
                    DurationMinutes = trainingDto.DurationMinutes,
                    TrainingType = trainingDto.TrainingType,
                    PerformanceScore = trainingDto.PerformanceScore,
                    Passed = Passed,
                    Evaluator = trainingDto.Evaluator
                };
                if (newTraining.SessionDate >= DateTime.UtcNow)
                {
                    return null;
                }
                _context.TrainingSessions.Add(newTraining);
                await _context.SaveChangesAsync();
                return new TrainingDto
                {
                    TrainingId = newTraining.Id,
                    SessionDate = newTraining.SessionDate,
                    PerformanceScore = newTraining.PerformanceScore,
                    TrainingType = newTraining.TrainingType,
                    DurationMinutes = newTraining.DurationMinutes,
                    Passed = newTraining.Passed,
                    Evaluator = newTraining.Evaluator
                };
            }
            catch
            {
                return null;
            }
        }
    }
}
