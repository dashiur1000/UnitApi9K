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
        public async Task<ICollection<CreateTrainingDto>> GetTrainingByIdAsync(int id)
        {
            return await _context.TrainingSessions
                .Where(d => d.Id == id)
                .Select(a => new CreateTrainingDto
                 {
                     DogId = a.DogId,
                     DurationMinutes = a.DurationMinutes,
                     Evaluator = a.Evaluator,
                     PerformanceScore = a.PerformanceScore,
                     SessionDate = a.SessionDate,
                     TrainingType = a.TrainingType
                 }).ToListAsync();
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
                var dog = await _context.Dogs.Where(d => d.Id == trainingDto.DogId).Where(d => d.Status != "Retired").Select(a => new DogDto
                {
                    Id = a.Id,
                    Name = a.Name,
                    DateOfBirth = a.DateOfBirth,
                    Breed = a.Breed,
                    MicrochipId = a.MicrochipId,
                    Specialty = a.Specialty,
                    Status = a.Status,
                }).ToListAsync();
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
                if (newTraining.SessionDate >= DateTime.Today)
                {
                    return null;
                }
                if(newTraining.SessionDate < DateTime.UtcNow)
                _context.TrainingSessions.Add(newTraining);
                await _context.SaveChangesAsync();
                return new TrainingDto
                {
                    DogId = newTraining.DogId,
                    TrainingId = newTraining.Id,
                    SessionDate = newTraining.SessionDate,
                    PerformanceScore = newTraining.PerformanceScore,
                    TrainingType = newTraining.TrainingType,
                    Passed = newTraining.Passed,
                    DurationMinutes = newTraining.DurationMinutes,
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
