using Microsoft.AspNetCore.Mvc;
using API.Domain;
using API.Services;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PromptController : ControllerBase
    {
        private readonly IPromptService _promptService;

        public PromptController(IPromptService promptService)
        {
            _promptService = promptService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var prompts = await _promptService.GetAllAsync();
            return Ok(prompts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var prompt = await _promptService.GetByIdAsync(id);
            if (prompt == null)
                return NotFound("Prompt não encontrado.");

            return Ok(prompt);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Prompt prompt)
        {
            var success = await _promptService.CreateAsync(prompt);
            return success ? Ok("Prompt criado com sucesso!") : BadRequest("Erro ao criar prompt.");
        }
    }
}
