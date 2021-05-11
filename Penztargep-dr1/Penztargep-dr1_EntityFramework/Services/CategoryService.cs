using Microsoft.EntityFrameworkCore;
using Penztargep_dr1_Domain.Models;
using Penztargep_dr1_Domain.Services;
using System.Threading.Tasks;

namespace Penztargep_dr1_EntityFramework.Services {
    public class CategoryService : GenericDataService<Category>, ICategoryService {
        public CategoryService(PenztargepDbContextFactory contextFactory) : base(contextFactory) {
        }

        public async Task<Category> GetByName(string name) {
            using (PenztargepDbContext context = _contextFactory.CreateDbContext()) {
                return await context.Categories.FirstOrDefaultAsync((entity) => entity.Name == name);
            }
        }
    }
}
