namespace API.Domain
{
    public class Chat
    {
        public int Id { get; set; }

        public int UserId { get; set; }

       
        public int? LastMessageId { get; set; }

      
        public List<Message>? Messages { get; set; }

        
        public int? LastPromptId { get; set; }
    }
}

