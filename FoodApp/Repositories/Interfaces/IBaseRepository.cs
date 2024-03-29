﻿using FoodApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodApp.Repositories
{
    public interface IBaseRepository<T> where T: BaseEntity
    {
        Task<T> GetAsync(object id);

        Task<IEnumerable<T>> GetAllAsync();

        Task<T> CreateAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task<bool> DeleteAsync(object id);

        Task<bool> Exists(object id);
    }
}
