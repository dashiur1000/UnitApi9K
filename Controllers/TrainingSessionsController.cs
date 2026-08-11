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
        [HttpPost]
        public async Task<ActionResult<CreateTrainingDto>> CreateTraining(CreateTrainingDto trainingDto)
        {
            var result = _trainingSessionsRepository.CreateTrainingAsync(trainingDto);
            if (result == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(CreateTraining), result);
        }
    }
}
