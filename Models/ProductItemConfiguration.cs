using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProductApi.Models
{
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
}
