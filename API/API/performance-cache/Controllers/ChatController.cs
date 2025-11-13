using Microsoft.AspNetCore.Mvc;
using API.Domain;
using API.Services;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly IChatService _chatService;

        public ChatController(IChatService chatService)
        {
            _chatService = chatService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var chats = await _chatService.GetAllAsync();
            return Ok(chats);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var chat = await _chatService.GetByIdAsync(id);
            if (chat == null)
                return NotFound("Chat não encontrado.");

            return Ok(chat);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Chat chat)
        {
            var success = await _chatService.CreateAsync(chat);
            return success ? Ok("Chat criado com sucesso!") : BadRequest("Erro ao criar chat.");
        }

        [HttpGet("{id}/messages")]
        public async Task<IActionResult> GetChatMessages(int id)
        {
            var messages = await _chatService.GetChatMessagesAsync(id);
            return Ok(messages);
        }
    }
}
