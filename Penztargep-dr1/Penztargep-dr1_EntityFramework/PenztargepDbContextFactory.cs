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
            // TODO : make it relative
            options.UseSqlite(@"Data Source=C:\Users\balin\Desktop\penztar-private\Penztargep-dr1\Penztargep-dr1_EntityFramework\Database.db;");

            return new PenztargepDbContext(options.Options);
        }
    }
}
