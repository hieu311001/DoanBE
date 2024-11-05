using ProductOrder.Entities;
using ProductOrder.Parameters;
using ProductOrder.Repos.Interfaces;
using ProductOrder.Services.Interfaces;

namespace ProductOrder.Services.Services
{
    public class StorageOrderService : BaseService<StorageOrderEntity, IStorageOrderRepo>, IStorageOrderService
    {
        public StorageOrderService(IStorageOrderRepo repo) : base(repo)
        {
        }

        public bool CreateStoreOrder(CreateStoreOrderParam param)
        {
            return _repo.CreateStoreOrder(param);
        }
    }
}
