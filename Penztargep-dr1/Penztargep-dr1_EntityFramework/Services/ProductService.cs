using Microsoft.EntityFrameworkCore;
using Penztargep_dr1_Domain.Models;
using Penztargep_dr1_Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penztargep_dr1_EntityFramework.Services {
    public class ProductService : GenericDataService<Product>, IProductService {
        public ProductService(PenztargepDbContextFactory contextFactory) : base(contextFactory) {
        }


        
        public async Task<IEnumerable<Product>> GetByCategory(Category category) {
            using (PenztargepDbContext context = _contextFactory.CreateDbContext()) {
                return await context.Products.Include(p => p.Category).Where(p => p.Category == category).ToListAsync();
            }
        }

        public async Task<Product> GetByCode(int code) {
            using (PenztargepDbContext context = _contextFactory.CreateDbContext()) {
                return await context.Products.FirstOrDefaultAsync((entity) => entity.Code == code);
            }
        }
    }
}
