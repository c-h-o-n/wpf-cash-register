using Penztargep_dr1_Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Penztargep_dr1_Domain.Services {
    public interface IUserService : IDataService<User> {
        /// <summary>
        /// Gets a User object by it's username.
        /// </summary>
        /// <param name="username"></param>
        /// <returns>Found User object.</returns>
        Task<User> GetByUsername(string username);
    }
}
