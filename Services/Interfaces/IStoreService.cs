using ProductOrder.Entities;

namespace ProductOrder.Services.Interfaces
{
    public interface IStoreService : IBaseService<StoreEntity>
    {
        dynamic GetStorageReport(bool isMonth);
        dynamic GetStoreReport(bool isMonth);
    }
}
