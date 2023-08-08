using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TasksAPI.Application.Dtos.Users;
using TasksAPI.Application.Ports.Application;

namespace TasksAPI.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserAppService? _userAppService;

        public UsersController(IUserAppService? userAppService)
        {
            _userAppService = userAppService;
        }

        [Route("create")]
        [HttpPost]
        [ProducesResponseType(typeof(UserCreateResponseDto), 201)]
        public IActionResult Create([FromBody] UserCreateRequestDto dto)
        {
            return StatusCode(201, _userAppService?.Create(dto));
        }

        [Route("auth")]
        [HttpPost]
        [ProducesResponseType(typeof(UserAuthResponseDto), 200)]
        public IActionResult Auth([FromBody] UserAuthRequestDto dto)
        {
            return StatusCode(200, _userAppService?.Authentication(dto));
        }
    }
}
