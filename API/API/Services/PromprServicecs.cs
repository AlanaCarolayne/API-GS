using API.Domain;
using API.Repository;

namespace API.Services
{
    public class PromprServicecs : IPromptService
    {
        private readonly IPromptRepository _promptRepository;

        public PromprServicecs(IPromptRepository promptRepository)
        {
            _promptRepository = promptRepository;
        }

        public async Task<IEnumerable<Prompt>> GetAllAsync()
        {
            return await _promptRepository.GetAllAsync();
        }

        public async Task<Prompt?> GetByIdAsync(int id)
        {
            return await _promptRepository.GetByIdAsync(id);
        }

        public async Task<bool> CreateAsync(Prompt prompt)
        {
            var rows = await _promptRepository.CreateAsync(prompt);
            return rows > 0;
        }
    }
}
