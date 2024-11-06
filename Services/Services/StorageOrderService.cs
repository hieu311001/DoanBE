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

        public dynamic AcceptStorageOrder(string storageOrderID)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();

            param.Add("storageOrderID", storageOrderID);

            dynamic result = _repo.ExecuteProc("Proc_AcceptStorageOrder", param);
            return result;
        }

        public bool CreateStoreOrder(CreateStoreOrderParam param)
        {
            return _repo.CreateStoreOrder(param);
        }

        public dynamic GetProductByStorageOrder(Guid? storageOrderID)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();

            param.Add("storageOrderID", storageOrderID);

            dynamic result = _repo.ExecuteProc("Proc_GetProductByStorageOrder", param);
            return result;
        }
    }
}
