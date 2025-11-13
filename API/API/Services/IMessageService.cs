using API.Domain;

namespace API.Services
{
    public interface IMessageService
    {
        Task<IEnumerable<Message>> GetMessagesByChatAsync(int chatId);
        Task<bool> CreateAsync(Message message);
    }
}
