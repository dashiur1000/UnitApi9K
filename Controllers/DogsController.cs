using Microsoft.AspNetCore.Mvc;
using UnitApi9K.DTOs;
using UnitApi9K.Repositories;

namespace UnitApi9K.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DogsController : ControllerBase
    {
        private readonly IDogsRepository _ogsRepository;
        public DogsController(IDogsRepository ogsRepository)
        {
            _ogsRepository = ogsRepository;
        }
        [HttpGet("id")]
        public async Task<ActionResult<DogDto>> GetDogById(int id)
        {
            var result = await _ogsRepository.GetDogByIdAsync(id);
            return Ok(result);
        }
    }
}
