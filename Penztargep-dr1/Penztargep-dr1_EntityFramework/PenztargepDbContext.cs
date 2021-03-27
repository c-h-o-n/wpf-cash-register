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


    }
}
