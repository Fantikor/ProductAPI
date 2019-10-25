using Microsoft.EntityFrameworkCore;

namespace ProductApi.Models
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductItemConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ProductItem> ProductItems { get; set; }
    }
}
