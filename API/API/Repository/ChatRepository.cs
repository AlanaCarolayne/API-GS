using API.Domain;
using Dapper;
using MySqlConnector;

namespace API.Repository
{
    public class ChatRepository : IChatRepository
    {
        private readonly MySqlConnection _connection;
        public ChatRepository(string connectionString)
        {
            _connection = new MySqlConnection(connectionString);
        }

        public async Task<IEnumerable<Chat>> GetAllAsync()
        {
            var query = "SELECT * FROM Chats";
            await using (_connection) 
            {
                if (_connection.State == System.Data.ConnectionState.Closed)
                {
                    await _connection.OpenAsync();
                }
                return await _connection.QueryAsync<Chat>(query);
            }
        }

        public async Task<Chat?> GetByIdAsync(int id)
        {
            var query = "SELECT * FROM Chats WHERE Id = @id";
            await using (_connection) 
            {
                if (_connection.State == System.Data.ConnectionState.Closed)
                {
                    await _connection.OpenAsync();
                }
                return await _connection.QueryFirstOrDefaultAsync<Chat>(query, new { id });
            }
        }

        public async Task<int> CreateAsync(Chat chat)
        {
            var query = @"INSERT INTO Chats (UserId, LastMessageId, LastPromptId)
                                VALUES (@UserId, @LastMessageId, @LastPromptId)";
            await using (_connection) 
            {
                if (_connection.State == System.Data.ConnectionState.Closed)
                {
                    await _connection.OpenAsync();
                }
                return await _connection.ExecuteAsync(query, chat);
            }
        }
    }
}
