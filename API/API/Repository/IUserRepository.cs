using API.Domain;

namespace API.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task<int> CreateAsync(User user);
    }
}
