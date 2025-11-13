using API.Domain;
using Dapper;
using MySqlConnector;

namespace API.Repository
{
    public class UserRepository
    {
        private readonly MySqlConnection _connection;
        public UserRepository(string connectionString)
        {
            _connection = new MySqlConnection(connectionString);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var query = "SELECT * FROM Users";
            await _connection.OpenAsync(); 
            return await _connection.QueryAsync<User>(query);
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            var query = "SELECT * FROM Users WHERE Id = @id";
            await _connection.OpenAsync(); 
            return await _connection.QueryFirstOrDefaultAsync<User>(query, new { id });
        }

        public async Task<int> CreateAsync(User user)
        {
            var query = @"INSERT INTO Users (Name)
                              VALUES (@Name)";
            await _connection.OpenAsync(); 
            return await _connection.ExecuteAsync(query, user);
        }
    }
}
}
