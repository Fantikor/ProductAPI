using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProductApi.Models
{
    public class ProductItem
    {
        public ProductItem()
        {
        }

        public ProductItem(Guid itemID)
        {
            ItemID = itemID;
        }

        public Guid ItemID { get; set; }
        public string ItemName { get; set; }
        public decimal? ItemPrice { get; set; }
    }

    public class ProductItemConfiguration : IEntityTypeConfiguration<ProductItem>
    {
        public void Configure(EntityTypeBuilder<ProductItem> builder)
        {
            // Set configuration for entity
            builder.ToTable("ProductItems");

            // Set key for entity
            builder.HasKey(p => p.ItemID);

            // Set configuration for columns
            builder.Property(p => p.ItemName).HasColumnType("nvarchar(100)").IsRequired();
            builder.Property(p => p.ItemPrice).HasColumnType("decimal(18,2)").IsRequired();

            // Columns with default value
            builder.Property(p => p.ItemID).HasColumnType("guid").IsRequired().HasDefaultValue(Guid.NewGuid());
        }
    }

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
