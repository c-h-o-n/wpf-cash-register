using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Penztargep_dr1_Domain.Models;
using Penztargep_dr1_Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Penztargep_dr1_EntityFramework.Services {
    public class GenericDataService<T> : IDataService<T> where T : DomainObject {
        protected readonly PenztargepDbContextFactory _contextFactory;

        public GenericDataService(PenztargepDbContextFactory contextFactory) {
            _contextFactory = contextFactory;
        }

        public async Task<T> Create(T entity) {
            using (PenztargepDbContext context = _contextFactory.CreateDbContext()) {
                EntityEntry<T> createdResult = await context.Set<T>().AddAsync(entity);
                await context.SaveChangesAsync();

                return createdResult.Entity;
            }
        }

        public async Task<bool> Delete(int id) {
            using (PenztargepDbContext context = _contextFactory.CreateDbContext()) {
                T entity = await context.Set<T>().FirstOrDefaultAsync((entity) => entity.Id == id);
                context.Set<T>().Remove(entity);
                await context.SaveChangesAsync();

                return true;
            }
        }

        public async Task<T> Get(int id) {
            using (PenztargepDbContext context = _contextFactory.CreateDbContext()) {
                T entity = await context.Set<T>().FirstOrDefaultAsync((entity) => entity.Id == id);
                return entity;
            }

        }

        public async Task<IEnumerable<T>> GetAll() {
            using (PenztargepDbContext context = _contextFactory.CreateDbContext()) {
                IEnumerable<T> entities = await context.Set<T>().ToListAsync();
                return entities;
            }
        }

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
