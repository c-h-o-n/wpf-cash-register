using Penztargep_dr1_Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Penztargep_dr1_Domain.Services {
    public interface ICategoryService : IDataService<Category> {
        /// <summary>
        /// Get Category by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Found category.</returns>
        Task<Category> GetByName(string name);
    }
}
