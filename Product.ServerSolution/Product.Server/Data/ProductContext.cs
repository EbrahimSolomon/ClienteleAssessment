using Microsoft.EntityFrameworkCore;
using Product.Server.Models;

namespace Product.Server.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options)
        {
        }

        public DbSet<Product.Server.Models.Product> Products { get; set; } = null!;
    }
}
