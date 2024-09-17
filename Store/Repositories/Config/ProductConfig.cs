using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p=>p.ProductId);
            builder.Property(p=>p.ProductName).IsRequired();
            builder.Property(p=>p.Price).IsRequired();

            builder.HasData(
                new Product() { ProductId = 1, CategoryId=2, ProductName = "computer", Price = 17_000 },
                new Product() { ProductId = 2, CategoryId=2, ProductName = "Keybouadr", Price = 15_000 },
                new Product() { ProductId = 3, CategoryId=2, ProductName = "sa", Price = 100 },
                new Product() { ProductId = 4, CategoryId=1, ProductName = "as", Price = 12_000 },
                new Product() { ProductId = 5, CategoryId=1, ProductName = "computer", Price = 11_000 }
            );
        }
    }
}