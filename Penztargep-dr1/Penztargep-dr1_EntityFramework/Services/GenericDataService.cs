using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Penztargep_dr1_Domain.Models;
using Penztargep_dr1_Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Penztargep_dr1_EntityFramework.Services {
    public class GenericDataService<T> : IDataService<T> where T : DomainObject {
        private readonly PenztargepDbContextFactory _contextFactory;

        public GenericDataService(PenztargepDbContextFactory contextFactory) {
            _contextFactory = contextFactory;
        }

        /// <summary>
        /// Creates a new entity.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Created entity</returns>
        public async Task<T> Create(T entity) {
            using(PenztargepDbContext context = _contextFactory.CreateDbContext()) {
                EntityEntry<T> createdResult = await context.Set<T>().AddAsync(entity);
                await context.SaveChangesAsync();

                return createdResult.Entity;
            }
        }
        /// <summary>
        /// Finds an entity by Id and removes it.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True if it was successfully removed.</returns>
        /// TODO: check if delete operation was successful
        public async Task<bool> Delete(int id) {
            using (PenztargepDbContext context = _contextFactory.CreateDbContext()) {
                T entity = await context.Set<T>().FirstOrDefaultAsync((entity) => entity.Id == id);
                context.Set<T>().Remove(entity);
                return true;
            }
        }

        /// <summary>
        /// Finds an entity by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Found entity</returns>
        public async Task<T> Get(int id) {
            using (PenztargepDbContext context = _contextFactory.CreateDbContext()) {
                T entity = await context.Set<T>().FirstOrDefaultAsync((entity) => entity.Id == id);
                return entity;
            }

        }

        /// <summary>
        /// Gets all entity.
        /// </summary>
        /// <returns>List of entities</returns>
        public async Task<IEnumerable<T>> GetAll() {
            using (PenztargepDbContext context = _contextFactory.CreateDbContext()) {
                IEnumerable<T> entities = await context.Set<T>().ToListAsync();
                return entities;
            }
        }
        /// <summary>
        /// Updates an entity.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns>Updated entity</returns>
        public async Task<T> Update(int id, T entity) {
            using (PenztargepDbContext context = _contextFactory.CreateDbContext()) {
                entity.Id = id;
                
                context.Set<T>().Update(entity);
                await context.SaveChangesAsync();
                
                return entity;
            }
        }
    }
}
