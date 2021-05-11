using Microsoft.EntityFrameworkCore;
using Penztargep_dr1_Domain.Models;
using Penztargep_dr1_Domain.Services;
using System.Threading.Tasks;

namespace Penztargep_dr1_EntityFramework.Services {
    public class UserService : GenericDataService<User>, IUserService {
        public UserService(PenztargepDbContextFactory contextFactory) : base(contextFactory) {

        }

        public async Task<User> GetByUsername(string username) {
            using (PenztargepDbContext context = _contextFactory.CreateDbContext()) {
                return await context.Users
                    .Include(user => user.Employee) // get employee
                    .FirstOrDefaultAsync(user => user.Username == username);
            }
        }
    }
}
