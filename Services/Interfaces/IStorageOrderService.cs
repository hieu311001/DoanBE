using ProductOrder.Entities;
using ProductOrder.Parameters;

namespace ProductOrder.Services.Interfaces
{
    public interface IStorageOrderService : IBaseService<StorageOrderEntity>
    {
        dynamic AcceptStorageOrder(string storageOrderID);
        bool CreateStoreOrder(CreateStoreOrderParam param);
        bool CreateStoreOrderByStorage(CreateStoreOrderParam param);
        dynamic GetAllStorageOrderByStorage(Guid storeID);
        dynamic GetProductByStorageOrder(Guid? storageOrderID);
    }
}
