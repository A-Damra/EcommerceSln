namespace Ecommerce.Application.Interfaces
{
    public interface IModelRepository
    {
        Task<IEnumerable<Object>> GetAllAsync();

        Task<Object?> GetByGuidAsync(Guid guid);

        Task<int> CreateAsync(Object obj);

        Task<int> UpdateAsync(Object obj);

        Task<int> DeleteAsync(Guid guid);
    }
}
