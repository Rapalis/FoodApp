using FoodApp.DataAccess;
using FoodApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodApp.Repositories
{
    public class ProvidersRepository: BaseRepository<Provider>, IProvidersRepository
    {
        private readonly DatabaseContext _dbCtx;
        
        public ProvidersRepository(DatabaseContext dbCtx): base(dbCtx)
        {
            _dbCtx = dbCtx;
        }
    }
}
