using FoodApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodApp.Repositories
{
    public class BaseRepository<T>: IBaseRepository<T> where T: BaseEntity
    {
        private readonly DbContext _dbCtx;

        public BaseRepository(DbContext dbCtx)
        {
            _dbCtx = dbCtx;
        }

        public async Task<T> GetAsync(object id)
        {
            return await _dbCtx.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return  await _dbCtx.Set<T>().ToListAsync();
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _dbCtx.Set<T>().AddAsync(entity);
            await _dbCtx.SaveChangesAsync();
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            
            _dbCtx.Set<T>().Attach(entity);
            await _dbCtx.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(object id)
        {
            T entity = await GetAsync(id);
            if (entity == null)
                return false;

            _dbCtx.Set<T>().Remove(entity);
            await _dbCtx.SaveChangesAsync();
            
            return true;
        }
    }
}
