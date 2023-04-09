using Bookish.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookish.DataAccess
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Product>()
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Order>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<OrderProduct>()
                .HasKey(orderProduct => new { orderProduct.ProductId, orderProduct.OrderId });

            modelBuilder.Entity<OrderProduct>()
                .HasOne<Order>(x => x.Order)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.OrderId);

            modelBuilder.Entity<OrderProduct>()
                .HasOne<Product>(x => x.Product)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.ProductId);

            modelBuilder.Entity<User>()
                .HasKey(x => x.Id);

            base.OnModelCreating(modelBuilder);
        }     
    }
}
