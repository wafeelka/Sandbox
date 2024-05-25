using AsyncDapper.Models;
using Dapper;
using Npgsql;
using System.Data;
using static Dapper.SqlMapper;

namespace AsyncDapper
{
    public class UserRepository : BaseRepository<User>
    {
        private readonly string _connectionString;
        public UserRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("UserRepositoryConnectionString")!;
        }
        public override async Task CreateAsync(User entity, CancellationToken cancellationToken = default)
        {
            using IDbConnection connection = new NpgsqlConnection(_connectionString);
            connection.Open();
            var sqlExpression = "INSERT INTO public.users (id, name, age) VALUES (@Id, @Name, @Age);";
            await connection.ExecuteAsync(sqlExpression, entity);
        }

        public override async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {

            using IDbConnection connection = new NpgsqlConnection(_connectionString);
            connection.Open();
            var sqlExpression = "DELETE FROM public.users WHERE id = @Id";
            await connection.ExecuteAsync(sqlExpression, new { Id = id });
        }

        public override async Task<User> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            using IDbConnection connection = new NpgsqlConnection(_connectionString);
            connection.Open();
            var sqlExpression = "SELECT * FROM public.users WHERE id = @Id";
            return await connection.QueryFirstAsync<User>(sqlExpression, new { Id = id });
        }

        public override async Task<IEnumerable<User>> GetCollectionAsync(CancellationToken cancellationToken = default)
        {
            using IDbConnection connection = new NpgsqlConnection(_connectionString);
            connection.Open();
            var sqlExpression = "SELECT * FROM public.users";
            return await connection.QueryAsync<User>(sqlExpression);
        }

        public override Task SaveAsync(CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public override async Task UpdateAsync(User entity, CancellationToken cancellationToken = default)
        {
            using IDbConnection connection = new NpgsqlConnection(_connectionString);
            connection.Open();
            var sqlExpression = "UPDATE public.users SET name = @Name, age = @Age WHERE Id = @Id";
            await connection.ExecuteAsync(sqlExpression, entity);
        }
    }
}
