using Microsoft.EntityFrameworkCore;
using WebApplication4.Entities;

namespace WebApplication4.Data
{
    public class ProductTaskDbcontext : DbContext
    {
        public ProductTaskDbcontext(DbContextOptions<ProductTaskDbcontext> opt)
            : base(opt)
        { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = 1,
                    Name = "Customer1",
                    Surname = "Customer01"
                },
                new Customer
                {
                    Id = 2,
                    Name = "Customer2",
                    Surname = "Customer02"
                },
                new Customer
                {
                    Id = 3,
                    Name = "Customer3",
                    Surname = "Customer03"
                },
                new Customer
                {
                    Id = 4,
                    Name = "Customer4",
                    Surname = "Customer04"
                });
                modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Product1",
                    Price = 100,
                    Discount = 10
                },
                new Product
                {
                    Id = 2,
                    Name = "Product2",
                    Price = 200,
                    Discount = 20
                },
                new Product
                {
                    Id = 3,
                    Name = "Product3",
                    Price = 300,
                    Discount = 30
                },
                new Product
                {
                    Id = 4,
                    Name = "Product4",
                    Price = 400,
                    Discount = 40
                });
                modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    Id = 1,
                    ProductId = 1,
                    CustomerId = 2,
                    OrderDate = DateTime.Now,
                },
                new Order
                {
                    Id = 2,
                    ProductId = 2,
                    CustomerId = 1,
                    OrderDate = DateTime.Now,
                },
                new Order
                {
                    Id = 3,
                    ProductId = 3,
                    CustomerId = 4,
                    OrderDate = DateTime.Now,
                },
                new Order
                {
                    Id = 4,
                    ProductId = 4,
                    CustomerId = 3,
                    OrderDate = DateTime.Now,
                });
        }
    }
}
