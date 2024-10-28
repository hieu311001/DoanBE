using ProductOrder.Entities;
using ProductOrder.Repos.Interfaces;
using ProductOrder.Services.Interfaces;

namespace ProductOrder.Services.Services
{
    public class StoreService : BaseService<StoreEntity, IStoreRepo>, IStoreService
    {
        public StoreService(IStoreRepo repo) : base(repo)
        {
        }
    }
}
