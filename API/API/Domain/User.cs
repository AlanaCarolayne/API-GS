
namespace API.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<Chat>? Chats { get; set; }
    }
}




