using API.Domain;

namespace API.Repository
{
    public interface IPromptRepository
    {
        Task<IEnumerable<Prompt>> GetAllAsync();
        Task<Prompt?> GetByIdAsync(int id);
        Task<int> CreateAsync(Prompt prompt);
    }
}
