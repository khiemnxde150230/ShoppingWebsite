using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShoppingWebsite.Models;

namespace ShoppingWebsite.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; } = default!;
        public DbSet<Categories> Categories { get; set; } = default!;
        public DbSet<Customers> Customers { get; set; } = default!;
        public DbSet<OrderDetails> OrderDetails { get; set; } = default!;
        public DbSet<Orders> Orders { get; set; } = default!;
        public DbSet<Products> Products { get; set; } = default!;

        public DbSet<Suppliers> Suppliers { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.Property(e => e.UserName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.ToTable("Categories");

                entity.HasKey(e => e.CategoryID);

                entity.Property(e => e.CategoryID).HasColumnName("CategoryID");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.ToTable("Customers");

                entity.HasKey(e => e.CustomerID);

                entity.Property(e => e.CustomerID).HasColumnName("CustomerID");

                entity.Property(e => e.Password)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ContactName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OrderDetails>(entity =>
            {

                entity.ToTable("OrderDetails");

                entity.HasKey(e => new { e.OrderID, e.ProductID });

                entity.Property(e => e.UnitPrice).HasColumnType("money");

                entity.HasOne(d => d.Orders)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderID)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Products)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductID)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.ToTable("Orders");

                entity.HasKey(e => e.OrderID);

                entity.Property(e => e.Freight).HasColumnType("money");

                entity.Property(e => e.ShipAddress)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.Customers)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerID)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.ToTable("Products");

                entity.HasKey(e => e.ProductID);

                entity.Property(e => e.ProductName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UnitPrice).HasColumnType("money");

                entity.HasOne(d => d.Categories)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryID)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Suppliers)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.SupplierID)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Suppliers>(entity =>
            {

                entity.ToTable("Suppliers");

                entity.HasKey(e => e.SupplierID);

                entity.Property(e => e.SupplierID).HasColumnName("SupplierID");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });
        }


    }
}
