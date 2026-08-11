using Microsoft.AspNetCore.Mvc;
using UnitApi9K.DTOs;
using UnitApi9K.Repositories;

namespace UnitApi9K.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HandlersController : ControllerBase
    {
        private readonly IHandlersRepository _handlersRepository;
        public HandlersController(IHandlersRepository handlersRepository)
        {
            _handlersRepository = handlersRepository;
        }
        [HttpDelete("{handlerId}")]
        public async Task<ActionResult> RemoveHandler(int handlerId)
        {
            var result = _handlersRepository.Remove(handlerId);
            if (result == true)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
