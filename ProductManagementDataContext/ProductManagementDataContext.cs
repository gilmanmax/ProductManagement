using Microsoft.EntityFrameworkCore;
using ProductManagement.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.DataContext
{
    public class ProductManagementDataContext : DbContext
    {
        public ProductManagementDataContext(DbContextOptions<ProductManagementDataContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(e => {
                e.ToTable("Customers");
                e.HasKey(b => b.Id);
                e.HasMany(b => b.Orders)
                    .WithOne(b => b.Customer)
                    .HasForeignKey(b => b.CustomerId);
            });


            modelBuilder.Entity<Order>().HasMany(b => b.OrderLineItems)
                .WithOne(b => b.Order)
                .HasForeignKey(b => b.OrderId);

            modelBuilder.Entity<OrderLineItem>().HasOne(b => b.Order);
            modelBuilder.Entity<OrderLineItem>().HasOne(b => b.Product);            


        }
        public required DbSet<Customer> Customer { get; set; }
        public required DbSet<Order> Orders { get; set; }
        public required DbSet<OrderLineItem> OrderLineItems { get; set; }
        public required DbSet<Product> Products { get; set; }
    }
}
