using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Product.Server.Data;
using Product.Server.DTOs;
using Product.Server.Services;

namespace Product.Server.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _context;

        public ProductRepository(ProductContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product.Server.Models.Product>> GetAllAsync() =>
            await _context.Products.ToListAsync();

        public async Task<Product.Server.Models.Product?> GetByIdAsync(int id) =>
            await _context.Products.FindAsync(id);

        public async Task AddAsync(Product.Server.Models.Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product.Server.Models.Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Product.Server.Models.Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}