using System.Data.Common;
using API.Domain;
using Dapper;
using MySqlConnector;

namespace API.Repository
{
    public class MessageRepository
    {
        private readonly MySqlConnection _connection;
        public MessageRepository(string connectionString)
        {
            _connection = new MySqlConnection(connectionString);
        }

        public async Task<IEnumerable<Message>> GetAllByChatAsync(int chatId)
        {
            var query = "SELECT * FROM Messages WHERE ChatId = @chatId";
            await using (_connection) 
            {
                if (_connection.State == System.Data.ConnectionState.Closed)
                {
                    await _connection.OpenAsync();
                }
                return await _connection.QueryAsync<Message>(query, new { chatId });
            }
        }

        public async Task<int> CreateAsync(Message message)
        {
            var query = @"INSERT INTO Messages (Text, IsFromUser, ChatId, SentAt)
                              VALUES (@Text, @IsFromUser, @ChatId, @SentAt)";
            await using (_connection) 
            {
                if (_connection.State == System.Data.ConnectionState.Closed)
                {
                    await _connection.OpenAsync();
                }
                return await _connection.ExecuteAsync(query, message);
            }
        }
    }
}
