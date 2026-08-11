using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;
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
        [HttpGet("{id}")]
        public async Task<ActionResult<DogDto>> GetDogById(int id)
        {
            var result = await _dogsRepository.GetDogByIdAsync(id);
            if(result == null)
            {
                return NotFound();
            }
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
        [HttpGet("search")]
        public async Task<ActionResult<DogDto>> Search(string? specialty, string? status)
        {
            var result = await _dogsRepository.GetDogsByFilters(specialty, status);
            return Ok(result);
        }
        [HttpGet("with-handler")]
        public async Task<ActionResult<IEnumerable<DogWithHandlerDto>>> GetDogWithHandler()
        {
            var result = await _dogsRepository.GetDogWithHandlerAsync();
            return Ok(result);
        }
        [HttpGet("performance-summary")]
        public async Task<ActionResult<IEnumerable<DogWithPerformanceDto>>> GetDogWithPerformance()
        {
            var result = await _dogsRepository.GetperformanceSummaryAsync();
            return Ok(result);
        }
    }
}
