using ProductOrder.Entities;
using ProductOrder.Repos.Interfaces;

namespace ProductOrder.Repos.Repos
{
    public class StoreRepo : BaseRepo<StoreEntity>, IStoreRepo
    {
        public StoreRepo(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
