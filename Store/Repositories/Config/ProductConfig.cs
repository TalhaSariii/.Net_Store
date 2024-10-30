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
                new Product() { ProductId = 1, CategoryId=2,ImageUrl="/images/1.jpg", ProductName = "computer", Price = 17_000, ShowCase=false  },
                new Product() { ProductId = 2, CategoryId=2,ImageUrl="/images/2.jpg", ProductName = "Keybouadr", Price = 15_000 ,ShowCase=false},
                new Product() { ProductId = 3, CategoryId=2,ImageUrl="/images/3.jpg", ProductName = "sa", Price = 100, ShowCase=false },
                new Product() { ProductId = 4, CategoryId=1,ImageUrl="/images/4.jpg", ProductName = "as", Price = 12_000, ShowCase=false },
                new Product() { ProductId = 5, CategoryId=1,ImageUrl="/images/5.jpg", ProductName = "computer", Price = 11_000, ShowCase=false },
                new Product() { ProductId = 6, CategoryId=2,ImageUrl="/images/1.jpg", ProductName = "mouse", Price = 7_000, ShowCase=false },
                new Product() { ProductId = 7, CategoryId=2,ImageUrl="/images/2.jpg", ProductName = "book", Price = 5_000, ShowCase=false },
                new Product() { ProductId = 8, CategoryId=2,ImageUrl="/images/3.jpg", ProductName = "NoteBook", Price = 100, ShowCase=true },
                new Product() { ProductId = 9, CategoryId=1,ImageUrl="/images/4.jpg", ProductName = "Keys", Price = 1_000, ShowCase=true },
                new Product() { ProductId = 10, CategoryId=1,ImageUrl="/images/5.jpg", ProductName = "Bag", Price = 1_000, ShowCase=true }
            );
        }
    }
} 