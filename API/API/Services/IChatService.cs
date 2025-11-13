using API.Domain;

namespace API.Services
{
    public interface IChatService
    {
        Task<IEnumerable<Chat>> GetAllAsync();
        Task<Chat?> GetByIdAsync(int id);
        Task<bool> CreateAsync(Chat chat);
        Task<IEnumerable<Message>> GetChatMessagesAsync(int chatId);
    }
}
