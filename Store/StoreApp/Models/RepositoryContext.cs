using Microsoft.EntityFrameworkCore;

namespace StoreApp.Models
{
    public class RepositoryContext :DbContext
    {
        public DbSet<Product> Products { get; set; }

        public RepositoryContext(DbContextOptions<RepositoryContext>options)
        : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>()
            .HasData(
                new Product() {ProductId=1,ProductName="computer",Price=17_000},
                new Product() {ProductId=2,ProductName="Keybouadr",Price=15_000},
                new Product() {ProductId=3,ProductName="sa",Price=100},
                new Product() {ProductId=4,ProductName="as",Price=12_000},
                new Product() {ProductId=5,ProductName="computer",Price=11_000}


            );    
        }
    }
}