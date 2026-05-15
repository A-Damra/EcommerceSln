using Dapper;
using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Data;

namespace Ecommerce.Infrastructure.Repositories
{
    public class ProductRepository : IModelRepository
    {
        private readonly DapperContext dbContext;

        public ProductRepository(DapperContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Object>> GetAllAsync()
        {
            using var connection = dbContext.CreateConnection();

            return await connection.QueryAsync<Product>("SELECT * FROM Products");
        }

        public async Task<Object?> GetByGuidAsync(Guid productGuid)
        {
            using var connection = dbContext.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<Product>("SELECT * FROM Products WHERE ProductGuid = @ProductGuid",
                new { ProductGuid = productGuid });
        }

        public async Task<int> CreateAsync(Object product)
        {
            using var connection = dbContext.CreateConnection();

            string query = (@"INSERT INTO Products 
            (ProductGuid, CategoryGuid, Name, Description, ImageUrl, StockQuantity, Price, CreatedAt) 
            VALUES 
            (@ProductGuid, @CategoryGuid, @Name, @Description, @ImageUrl, @StockQuantity, @Price, @CreatedAt)");

            return await connection.ExecuteAsync(query, product);
        }

        public async Task<int> UpdateAsync(Object product)
        {
            using var connection = dbContext.CreateConnection();

            string query = (@"UPDATE Products 
            SET CategoryGuid = @CategoryGuid, 
            Name = @Name, Description = @Description, 
            ImageUrl = @ImageUrl, StockQuantity = @StockQuantity, Price = @Price
            WHERE ProductGuid = @ProductGuid");

            return await connection.ExecuteAsync(query, product);
        }

        public async Task<int> DeleteAsync(Guid productGuid)
        {
            using var connection = dbContext.CreateConnection();

            return await connection.ExecuteAsync("DELETE FROM Products WHERE ProductGuid = @ProductGuid",
                new { ProductGuid = productGuid });
        }
    }
}
