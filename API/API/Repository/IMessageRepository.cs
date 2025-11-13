using API.Domain;

namespace API.Repository
{
    public interface IMessageRepository
    {
        Task<IEnumerable<Message>> GetAllByChatAsync(int chatId);
        Task<int> CreateAsync(Message message);
    }
}
