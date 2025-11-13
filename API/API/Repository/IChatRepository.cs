using API.Domain;

namespace API.Repository
{
    public interface IChatRepository
    {
        Task<IEnumerable<Chat>> GetAllAsync();
        Task<Chat?> GetByIdAsync(int id);
        Task<int> CreateAsync(Chat chat);
    }
}
