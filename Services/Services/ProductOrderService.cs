using ProductOrder.Entities;
using ProductOrder.Parameters;
using ProductOrder.Repos.Interfaces;
using ProductOrder.Services.Interfaces;

namespace ProductOrder.Services.Services
{
    public class ProductOrderService : BaseService<ProductOrderEntity, IProductOrderRepo>, IProductOrderService
    {
        public ProductOrderService(IProductOrderRepo repo) : base(repo)
        {
        }

        public bool CreateOrder(CreateOrderParam param)
        {
            return _repo.CreateOrder(param);
        }

        public dynamic GetAllProductOrder(Guid? storeID)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();

            param.Add("storeID", storeID);

            dynamic result = _repo.ExecuteProc("Proc_GetAllProductOrder", param);
            return result;
        }

        public dynamic GetProductByProductOrder(Guid? productOrderID)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();

            param.Add("productOrderID", productOrderID);

            dynamic result = _repo.ExecuteProc("Proc_GetProductByProductOrder", param);
            return result;
        }

        public dynamic GetProductOrderByUserID(Guid? userID)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();

            param.Add("userID", userID);

            dynamic result = _repo.ExecuteProc("Proc_GetProductOrderByUserID", param);
            return result;
        }

        /// <summary>
        /// Cập nhật dữ liệu
        /// </summary>
        public override int Update(ProductOrderEntity item)
        {
            var res = _repo.Update(item);

            if (item.Status == Enums.ProductOrderStatus.Done)
            {
                Dictionary<string, object> param = new Dictionary<string, object>();

                param.Add("productOrderID", item.ProductOrderID);

                _repo.ExecuteProc("Proc_ProductOrderDone", param);
            }

            return res;
        }
    }
}
