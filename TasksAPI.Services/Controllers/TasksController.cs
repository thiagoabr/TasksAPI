using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TasksAPI.Application.Dtos.Tasks;
using TasksAPI.Application.Ports.Application;

namespace TasksAPI.Services.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskAppService? _taskAppService;

        public TasksController(ITaskAppService? taskAppService)
        {
            _taskAppService = taskAppService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(TaskGetResponseDto), 201)]
        public IActionResult Post([FromBody] TaskCreateRequestDto dto)
        {
            return StatusCode(201, _taskAppService?.Create(dto));
        }

        [HttpPut]
        [ProducesResponseType(typeof(TaskGetResponseDto), 200)]
        public IActionResult Put([FromBody] TaskUpdateRequestDto dto)
        {
            return StatusCode(200, _taskAppService?.Update(dto));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(TaskGetResponseDto), 200)]
        public IActionResult Delete(Guid? id)
        {
            var userId = Guid.Parse(User.Identity.Name);
            return StatusCode(200, _taskAppService?.Delete(id, userId));
        }

        [HttpGet("{dataMin}/{dataMax}")]
        [ProducesResponseType(typeof(List<TaskGetResponseDto>), 200)]
        public IActionResult Get(DateTime dataMin, DateTime dataMax)
        {
            var userId = Guid.Parse(User.Identity.Name);
            var tasks = _taskAppService?.GetAll(dataMin, dataMax, userId);

            if (tasks.Count > 0)
                return StatusCode(200, tasks);
            else
                return NoContent();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(TaskGetResponseDto), 200)]
        public IActionResult Get(Guid id)
        {
            var userId = Guid.Parse(User.Identity.Name);
            var task = _taskAppService?.GetById(id, userId);

            if (task != null)
                return StatusCode(200, task);
            else
                return NoContent();
        }
    }
}
