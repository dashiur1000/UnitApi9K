using Microsoft.AspNetCore.Mvc;
using UnitApi9K.DTOs;
using UnitApi9K.Repositories;

namespace UnitApi9K.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DogsController : ControllerBase
    {
        private readonly IDogsRepository _dogsRepository;
        public DogsController(IDogsRepository dogsRepository)
        {
            _dogsRepository = dogsRepository;
        }
        [HttpGet("id")]
        public async Task<ActionResult<DogDto>> GetDogById(int id)
        {
            var result = await _dogsRepository.GetDogByIdAsync(id);
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<DogDto>> CreateDog(CreateDogDto dto)
        {
            var result = await _dogsRepository.CreateDogAsync(dto);
            if (result == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(GetDogById), result, result);
        }
    }
}
