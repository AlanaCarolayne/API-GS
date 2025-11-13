using API.Domain;
using Dapper;
using MySqlConnector;

namespace API.Repository
{
    public class PromptRepository : IPromptRepository
    {
        private readonly MySqlConnection _connection;
        public PromptRepository(string connectionString)
        {
            _connection = new MySqlConnection(connectionString);
        }

        public async Task<IEnumerable<Prompt>> GetAllAsync()
        {
            var query = "SELECT * FROM Prompts";
            await _connection.OpenAsync();
            return await _connection.QueryAsync<Prompt>(query);
        }

        public async Task<Prompt?> GetByIdAsync(int id)
        {
            var query = "SELECT * FROM Prompts WHERE Id = @id";
            await _connection.OpenAsync(); 
            return await _connection.QueryFirstOrDefaultAsync<Prompt>(query, new { id });
        }

        public async Task<int> CreateAsync(Prompt prompt)
        {
            var query = @"INSERT INTO Prompts (Text, RelatedMessageId, ChatId, CreatedAt)
                              VALUES (@Text, @RelatedMessageId, @ChatId, @CreatedAt)";
            await _connection.OpenAsync(); 
            return await _connection.ExecuteAsync(query, prompt);
        }
    }
}
