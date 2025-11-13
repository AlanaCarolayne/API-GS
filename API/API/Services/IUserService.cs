using API.Domain;

namespace API.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task<bool> CreateAsync(User user);
        Task<IEnumerable<Chat>> GetUserChatsAsync(int userId);
    }
}
