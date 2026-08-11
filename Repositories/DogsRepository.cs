using Microsoft.EntityFrameworkCore;
using System.Collections;
using UnitApi9K.Data;
using UnitApi9K.DTOs;
using UnitApi9K.Models;

namespace UnitApi9K.Repositories
{
    public class DogsRepository : IDogsRepository
    {
        private readonly UnitManagementDbContext _context;
        public DogsRepository(UnitManagementDbContext context)
        {
            _context = context;
        }
        public async Task<ICollection<DogDto>> GetDogByIdAsync(int id)
        {
            return await _context.Dogs
                .Where (d => d.Id == id)
                .Select(a => new DogDto
                {
                    Id = a.Id,
                    Name = a.Name,
                    DateOfBirth = a.DateOfBirth,
                    Breed = a.Breed,
                    MicrochipId = a.MicrochipId,
                    Specialty = a.Specialty,
                    Status = a.Status,
                }).ToListAsync();
        }
        public async Task<DogDto> CreateDogAsync(CreateDogDto Dog)
        {
            try
            {
                var newDog = new Dog
                {
                    Name = Dog.Name,
                    DateOfBirth = Dog.DateOfBirth,
                    Breed = Dog.Breed,
                    MicrochipId = Dog.MicrochipId,
                    Specialty = Dog.Specialty,
                    Status = Dog.Status
                };
                if(newDog.DateOfBirth >= DateTime.Today)
                {
                    return null;
                }
                _context.Dogs.Add(newDog);
                await _context.SaveChangesAsync();
                return new DogDto
                {
                    Id = newDog.Id,
                    Name = newDog.Name,
                    Breed = newDog.Breed,
                    DateOfBirth = newDog.DateOfBirth,
                    MicrochipId = newDog.MicrochipId,
                    Specialty = newDog.Specialty,
                    Status = newDog.Status
                };
            }
            catch
            {
                return null;
            }
        }
        public async Task<ICollection<DogDto>> GetDogsByFilters(string? specialty, string? status)
        {
            var query = _context.Dogs.AsQueryable();
            if(string.IsNullOrEmpty(specialty))
            {
                query = query.Where(a => a.Specialty == specialty);
            }
            if(string.IsNullOrEmpty(status))
            {
                query = query.Where(a => a.Status == status);
            }
            return await query
                .Select(a => new DogDto
                {
                    Id=a.Id,
                    MicrochipId=a.MicrochipId,
                    Breed=a.Breed,
                    DateOfBirth=a.DateOfBirth,
                    Name = a.Name,
                    Specialty=a.Specialty,
                    Status=a.Status
                }).ToListAsync();
        }
        public async Task<ICollection<DogWithHandlerDto>> GetDogWithHandlerAsync()
        {
            return await _context.Dogs
                .Include(a => a.Handler)
                .Select(s => new DogWithHandlerDto
                {
                    DogId = s.Id,
                    DogName = s.Name,
                    DogBreed = s.Breed,
                    HandlerFullName = s.Handler.FullName,
                    HandlerRank = s.Handler.Rank
                }).ToListAsync();
        }
        public async Task<ICollection<DogWithPerformanceDto>> GetperformanceSummaryAsync()
        {
            return await _context.TrainingSessions
                .Include(a => a.Dog)
                .GroupBy(a => a.DogId)
                .Select(g => new DogWithPerformanceDto
                {
                    DogId = g.Key,
                    DogName = g.Select(x => x.Dog.Name).FirstOrDefault(),
                    Specialty = g.Select(x => x.Dog.Specialty).FirstOrDefault(),
                    Training = g.Count(),
                    PerformanceScoreAverage = g.Average(a => a.PerformanceScore),
                }).ToListAsync();

        }
    }
}
