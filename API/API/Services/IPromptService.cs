using API.Domain;

namespace API.Services
{
    public interface IPromptService
    {
        Task<IEnumerable<Prompt>> GetAllAsync();
        Task<Prompt?> GetByIdAsync(int id);
        Task<bool> CreateAsync(Prompt prompt);
    }
}
}
