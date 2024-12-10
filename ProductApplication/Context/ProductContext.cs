namespace ProductApplication.Context
{
    using Microsoft.EntityFrameworkCore;
    using ProductApplication.Models;

    public class ProductContext: DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }
        public required DbSet<ProductModel> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductModel>().ToTable("Products");
        }
    }
}
