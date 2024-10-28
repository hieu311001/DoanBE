using ProductOrder.Entities;
using ProductOrder.Repos.Interfaces;

namespace ProductOrder.Repos.Repos
{
    public class StorageOrderDetailRepo : BaseRepo<StorageOrderDetailEntity>, IStorageOrderDetailRepo
    {
        public StorageOrderDetailRepo(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
