using Penztargep_dr1_Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Penztargep_dr1_Domain.Services {
    public interface IProductService : IDataService<Product> {
        Task<IEnumerable<Product>> GetByCategory(Category category);
    }
}
