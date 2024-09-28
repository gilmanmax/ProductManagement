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

            #region User

            modelBuilder.Entity<User>(e =>
            {
                e.ToTable("Users");
                e.HasKey(e => e.Id);
                e.HasMany(b => b.UserTokens)
                    .WithOne(b => b.User)
                    .HasForeignKey(e => e.UserId)
                    .HasPrincipalKey(e=>e.Id);
            });

            modelBuilder.Entity<User>(e =>
            {
                e.HasKey(e => e.Id);
                e.HasMany(b => b.UserTokens)
                    .WithOne(b => b.User)
                    .HasForeignKey(e => e.UserId)
                    .HasPrincipalKey(e => e.Id);
            });

            modelBuilder.Entity<User>(e =>
            {
                e.HasKey(e => e.Id);
                e.HasMany(b => b.UserTokens)
                    .WithOne(b => b.User)
                    .HasForeignKey(e => e.UserId)
                    .HasPrincipalKey(e => e.Id);
            });
            #endregion User
            #region Customer
            modelBuilder.Entity<Customer>(e => {
                e.ToTable("Customers");
                e.HasKey(b => b.Id);
                e.HasMany(b => b.Orders)
                    .WithOne(b => b.Customer)
                    .HasForeignKey(b => b.CustomerId);

                e.HasOne(b => b.User);
            });

            #endregion
            modelBuilder.Entity<Order>().HasMany(b => b.OrderLineItems)
                .WithOne(b => b.Order)
                .HasForeignKey(b => b.OrderId)
                .HasPrincipalKey(b=>b.Id);

            modelBuilder.Entity<OrderLineItem>().HasOne(b => b.Order);
            modelBuilder.Entity<OrderLineItem>().HasOne(b => b.Product);            


        }


        #region OAuth
        public required DbSet<User> User { get; set; }
        public required DbSet<UserToken> UserToken { get; set; }
        #endregion

        public required DbSet<Customer> Customer { get; set; }
        public required DbSet<Order> Orders { get; set; }
        public required DbSet<OrderLineItem> OrderLineItems { get; set; }
        public required DbSet<Product> Products { get; set; }
    }
}
