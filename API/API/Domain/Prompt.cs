namespace API.Domain
{
   
    public class Prompt

    {
        public int Id { get; set; }

 
        public string Text { get; set; } = string.Empty;

        public int? RelatedMessageId { get; set; }

        public int ChatId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }
}
