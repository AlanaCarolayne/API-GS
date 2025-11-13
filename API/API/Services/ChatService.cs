using API.Domain;
using API.Repository;

namespace API.Services
{
    public class ChatService : IChatService
    {
        private readonly IChatRepository _chatRepository;
        private readonly IMessageRepository _messageRepository;

        public ChatService(IChatRepository chatRepository, IMessageRepository messageRepository)
        {
            _chatRepository = chatRepository;
            _messageRepository = messageRepository;
        }

        public async Task<IEnumerable<Chat>> GetAllAsync()
        {
            return await _chatRepository.GetAllAsync();
        }

        public async Task<Chat?> GetByIdAsync(int id)
        {
            return await _chatRepository.GetByIdAsync(id);
        }

        public async Task<bool> CreateAsync(Chat chat)
        {
            var rows = await _chatRepository.CreateAsync(chat);
            return rows > 0;
        }

        public async Task<IEnumerable<Message>> GetChatMessagesAsync(int chatId)
        {
            return await _messageRepository.GetAllByChatAsync(chatId);
        }
    }
}
