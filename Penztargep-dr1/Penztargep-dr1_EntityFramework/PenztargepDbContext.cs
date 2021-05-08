using Microsoft.EntityFrameworkCore;
using Penztargep_dr1_Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Penztargep_dr1_EntityFramework {
    public class PenztargepDbContext : DbContext {

        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<ReceiptItem> ReceiptItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public PenztargepDbContext(DbContextOptions options) : base(options) {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            // user - employee
            //modelBuilder.Entity<Employee>()
            //  .HasOne(a => a.User)
            //  .WithOne(b => b.Employee)
            //  .HasForeignKey<User>(b => b.EmployeeId);

            // employee < receipt
            modelBuilder.Entity<Employee>()
                .HasMany(position => position.Receipts)
                .WithOne(e => e.Employee)
                .HasForeignKey(employee => employee.EmployeeId);

            //receipt < receipt_item
            modelBuilder.Entity<Receipt>()
            .HasMany(ri => ri.ReceiptItems)
            .WithOne(r => r.Receipt)
            .HasForeignKey(r => r.ReceiptId);
            //product < receipt_item
            modelBuilder.Entity<Product>()
            .HasMany(ri => ri.ReceiptItems)
            .WithOne(p => p.Product)
            .HasForeignKey(p => p.ProductId);

            // category < product
            modelBuilder.Entity<Category>()
            .HasMany(c => c.Products)
            .WithOne(e => e.Category);
            base.OnModelCreating(modelBuilder);
        }


    }
}
