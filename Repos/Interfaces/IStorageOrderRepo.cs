using ProductOrder.Entities;
using ProductOrder.Parameters;

namespace ProductOrder.Repos.Interfaces
{
    public interface IStorageOrderRepo : IBaseRepo<StorageOrderEntity>
    {
        bool CreateStoreOrder(CreateStoreOrderParam param);
    }
}
