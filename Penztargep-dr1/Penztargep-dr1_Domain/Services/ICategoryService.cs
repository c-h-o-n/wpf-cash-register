using Penztargep_dr1_Domain.Models;
using System.Threading.Tasks;

namespace Penztargep_dr1_Domain.Services {
    public interface ICategoryService : IDataService<Category> {

        Task<Category> GetByName(string name);
    }
}
