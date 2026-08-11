using Microsoft.EntityFrameworkCore;
using System.Collections;
using UnitApi9K.Data;
using UnitApi9K.DTOs;

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
        public async Task<ICollection<DogDto>> GetDogByIdAsync(int id)
        {

        }
    }
}
