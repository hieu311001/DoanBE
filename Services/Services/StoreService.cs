using ProductOrder.Entities;
using ProductOrder.Repos.Interfaces;
using ProductOrder.Services.Interfaces;

namespace ProductOrder.Services.Services
{
    public class StoreService : BaseService<StoreEntity, IStoreRepo>, IStoreService
    {
        public StoreService(IStoreRepo repo) : base(repo)
        {
        }

        /// <summary>
        /// Thêm mới dữ liệu
        /// </summary>
        public override int Insert(StoreEntity item)
        {
            var res = _repo.Insert(item);

            if (res != 0)
            {
                Dictionary<string, object> param = new Dictionary<string, object>();

                param.Add("storeID", item.StoreID);

                dynamic result = _repo.ExecuteProc("Proc_AddStore", param);
            }

            return res;
        }
    }
}
