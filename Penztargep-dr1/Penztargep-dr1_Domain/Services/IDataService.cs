using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Penztargep_dr1_Domain.Services {
    public interface IDataService<T> {
        /// <summary>
        /// Gets all entity.
        /// </summary>
        /// <returns>List of entities</returns>
        Task<IEnumerable<T>> GetAll();
        /// <summary>
        /// Gets an entity by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Found entity</returns>
        Task<T> Get(int id);

        /// <summary>
        /// Creates a new entity.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Created entity</returns>
        Task<T> Create(T entity);
        /// <summary>
        /// Updates an entity.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns>Updated entity</returns>
        Task<T> Update(int id, T entitiy);
        /// <summary>
        /// Finds an entity by Id and removes it.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True if it was successfully removed.</returns>
        /// TODO: check if delete operation was successful
        Task<bool> Delete(int id);
    }
}
