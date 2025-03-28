namespace Product.Server.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product.Server.Models.Product>> GetAllAsync();
        Task<Product.Server.Models.Product?> GetByIdAsync(int id);
        Task AddAsync(Product.Server.Models.Product product);
        Task UpdateAsync(Product.Server.Models.Product product);
        Task DeleteAsync(Product.Server.Models.Product product);
    }
}
