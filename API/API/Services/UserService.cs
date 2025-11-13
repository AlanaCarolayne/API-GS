using API.Domain;
using API.Repository;

namespace API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IChatRepository _chatRepository;

        public UserService(IUserRepository userRepository, IChatRepository chatRepository)
        {
            _userRepository = userRepository;
            _chatRepository = chatRepository;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<bool> CreateAsync(User user)
        {
            var rows = await _userRepository.CreateAsync(user);
            return rows > 0;
        }

        public async Task<IEnumerable<Chat>> GetUserChatsAsync(int userId)
        {
            var chats = await _chatRepository.GetAllAsync();
            return chats.Where(c => c.UserId == userId);
        }
    }
}
