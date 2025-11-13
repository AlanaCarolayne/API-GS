namespace API.Domain
{
    public class Message
    {
       
        public int Id { get; set; }

        
        public string Text { get; set; } = string.Empty;

      
        public bool IsFromUser { get; set; }

       
        public int ChatId { get; set; }

      
        public DateTime SentAt { get; set; } = DateTime.UtcNow;
    
}
