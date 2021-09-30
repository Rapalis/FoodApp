using FoodApp.DataAccess;
using FoodApp.Models;

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
