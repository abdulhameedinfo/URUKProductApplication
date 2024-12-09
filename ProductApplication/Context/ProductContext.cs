namespace ProductApplication.Context
{
    using Microsoft.EntityFrameworkCore;
    using ProductApplication.Models;

    public class ProductContext: DbContext
    {
        public required DbSet<ProductModel> Products { get; set; }

        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductModel>().ToTable("Products");
        }
    }
}
