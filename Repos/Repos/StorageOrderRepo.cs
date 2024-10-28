using ProductOrder.Entities;
using ProductOrder.Repos.Interfaces;

namespace ProductOrder.Repos.Repos
{
    public class StorageOrderRepo : BaseRepo<StorageOrderEntity>, IStorageOrderRepo
    {
        public StorageOrderRepo(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
