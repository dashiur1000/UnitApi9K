using Microsoft.AspNetCore.Mvc;
using UnitApi9K.DTOs;
using UnitApi9K.Repositories;

namespace UnitApi9K.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrainingSessionsController : ControllerBase
    {
        private readonly ITrainingSessionsRepository _trainingSessionsRepository;
        public TrainingSessionsController(ITrainingSessionsRepository trainingSessionsRepository)
        {
            _trainingSessionsRepository = trainingSessionsRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CreateTrainingDto>>> GetById(int id)
        {
            var result = await _trainingSessionsRepository.GetTrainingByIdAsync(id);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<CreateTrainingDto>> CreateTraining(CreateTrainingDto trainingDto)
        {
            var result =  await _trainingSessionsRepository.CreateTrainingAsync(trainingDto);
            if (result == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(GetById), result);
        }
        [HttpGet("detailed")]
        public async Task<ActionResult<IEnumerable<TrainingWithDogAndHandlerDto>>> GetAllTrainingWithDogAndHandler()
        {
            var result = await _trainingSessionsRepository.GetAllDetailedAsync();
            return Ok(result);
        }
        [HttpGet("paged")]
        public async Task<ActionResult<IEnumerable<TrainingSessionPagedDto>>> GetTrainingByPage(int page = 1, int pageSize = 10)
        {
            var result = await _trainingSessionsRepository.GetPagedAsync(page, pageSize);
            return Ok(result);
        }
    }

}
