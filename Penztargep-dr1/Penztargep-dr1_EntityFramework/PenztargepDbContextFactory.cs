using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Penztargep_dr1_EntityFramework {
    /// <summary>
    /// Hides connection string. Temporary!! 
    /// </summary>
    public class PenztargepDbContextFactory : IDesignTimeDbContextFactory<PenztargepDbContext> {
    public PenztargepDbContext CreateDbContext(string[] args = null) {
            var options = new DbContextOptionsBuilder<PenztargepDbContext>();
            options.UseSqlite(@"Data Source=Database.db;");

            return new PenztargepDbContext(options.Options);
        }
    }
}
