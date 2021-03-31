using Microsoft.EntityFrameworkCore;
using Penztargep_dr1_Domain.Models;
using Penztargep_dr1_Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Penztargep_dr1_EntityFramework.Services {
    public class ProductService : GenericDataService<Product>, IDataService<Product> {
        public ProductService(PenztargepDbContextFactory contextFactory) : base(contextFactory) {
        }

        public override async Task<IEnumerable<Product>> GetAll() {
            using (PenztargepDbContext context = _contextFactory.CreateDbContext()) {
                IEnumerable<Product> entities = await context.Set<Product>().Include(product => product.Category).ToListAsync();
                return entities;
            }
        }
    }
}
