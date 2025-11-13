using API.Domain;
using API.Repository;

namespace API.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;

        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task<IEnumerable<Message>> GetMessagesByChatAsync(int chatId)
        {
            return await _messageRepository.GetAllByChatAsync(chatId);
        }

        public async Task<bool> CreateAsync(Message message)
        {
            var rows = await _messageRepository.CreateAsync(message);
            return rows > 0;
        }
    }
}
