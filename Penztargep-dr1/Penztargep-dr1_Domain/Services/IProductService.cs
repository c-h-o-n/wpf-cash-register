using Penztargep_dr1_Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Penztargep_dr1_Domain.Services {
    public interface IProductService : IDataService<Product> {
        /// <summary>
        /// Gets a Product by Category.
        /// </summary>
        /// <param name="category"></param>
        /// <returns>Found products.</returns>
        Task<IEnumerable<Product>> GetByCategory(Category category);
        /// <summary>
        /// Gets a Product by Code.
        /// </summary>
        /// <param name="code"></param>
        /// <returns>Found product.</returns>
        Task<Product> GetByCode(int code);

    }
}
