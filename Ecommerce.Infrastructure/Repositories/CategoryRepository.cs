using Dapper;
using Ecommerce.Application.Interfaces;
using Ecommerce.Infrastructure.Data;

namespace Ecommerce.Infrastructure.Repositories
{
    public class CategoryRepository : IModelRepository
    {
        private readonly DapperContext dapperContext;

        public CategoryRepository(DapperContext dapperContext)
        {
            this.dapperContext = dapperContext;
        }

        public async Task<int> CreateAsync(object obj)
        {
            using var connection = dapperContext.CreateConnection();

            string query = (@"INSERT INTO Categories
            VALUES (@CategoryGuid, @CategoryParent, @Name, @IsActive)");

            return await connection.ExecuteAsync(query, obj);
        }

        public async Task<int> DeleteAsync(Guid guid)
        {
            using var connection = dapperContext.CreateConnection();

            string query = (@"UPDATE Categories SET IsActive = 0 WHERE CategoryGuid = @CategoryGuid");

            return await connection.ExecuteAsync(query, new { CategoryGuid = guid });
        }

        public async Task<IEnumerable<Object>> GetAllAsync()
        {
            using var connection = dapperContext.CreateConnection();

            string query = (@"SELECT * FROM Categories");

            return await connection.QueryAsync<Object>(query);
        }

        public async Task<Object?> GetByGuidAsync(Guid guid)
        {
            using var connection = dapperContext.CreateConnection();

            string query = (@"SELECT * FROM Categories WHERE CategoryGuid = @CategoryGuid");

            return await connection.QueryFirstOrDefaultAsync<Object>(query, new { CategoryGuid = guid });
        }

        public async Task<int> UpdateAsync(object obj)
        {
            using var connection = dapperContext.CreateConnection();

            string query = (@"UPDATE Categories SET CategoryParent = @CategoryParent, Name = @Name, IsActive = @IsActive
            WHERE CategoryGuid = @CategoryGuid");

            return await connection.ExecuteAsync(query, obj);
        }
    }
}
