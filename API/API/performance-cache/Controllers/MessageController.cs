using Microsoft.AspNetCore.Mvc;
using API.Domain;
using API.Services;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet("chat/{chatId}")]
        public async Task<IActionResult> GetMessagesByChat(int chatId)
        {
            var messages = await _messageService.GetMessagesByChatAsync(chatId);
            return Ok(messages);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Message message)
        {
            var success = await _messageService.CreateAsync(message);
            return success ? Ok("Mensagem criada com sucesso!") : BadRequest("Erro ao criar mensagem.");
        }
    }
}
