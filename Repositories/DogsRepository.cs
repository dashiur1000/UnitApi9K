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
                if(newDog.DateOfBirth >= DateTime.UtcNow)
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
    }
}
