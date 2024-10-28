using ProductOrder.Entities;
using ProductOrder.Repos.Interfaces;
using ProductOrder.Services.Interfaces;

namespace ProductOrder.Services.Services
{
    public class StorageOrderDetailService : BaseService<StorageOrderDetailEntity, IStorageOrderDetailRepo>, IStorageOrderDetailService
    {
        public StorageOrderDetailService(IStorageOrderDetailRepo repo) : base(repo)
        {
        }
    }
}
