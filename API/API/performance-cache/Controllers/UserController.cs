using Microsoft.AspNetCore.Mvc;
using API.Domain;
using API.Services;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
                return NotFound("Usuário não encontrado.");

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] User user)
        {
            var success = await _userService.CreateAsync(user);
            return success ? Ok("Usuário criado com sucesso!") : BadRequest("Erro ao criar usuário.");
        }

        [HttpGet("{id}/chats")]
        public async Task<IActionResult> GetUserChats(int id)
        {
            var chats = await _userService.GetUserChatsAsync(id);
            return Ok(chats);
        }
    }
}