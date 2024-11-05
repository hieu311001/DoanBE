using ProductOrder.Entities;
using ProductOrder.Parameters;

namespace ProductOrder.Services.Interfaces
{
    public interface IStorageOrderService : IBaseService<StorageOrderEntity>
    {
        bool CreateStoreOrder(CreateStoreOrderParam param);
    }
}
