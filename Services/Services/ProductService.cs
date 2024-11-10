using Microsoft.AspNetCore.Mvc;
using ProductOrder.Entities;
using ProductOrder.Repos.Interfaces;
using ProductOrder.Services.Interfaces;

namespace ProductOrder.Services.Services
{
    public class ProductService : BaseService<ProductEntity, IProductRepo>, IProductService
    {
        public ProductService(IProductRepo repo) : base(repo)
        {
        }

        public dynamic GetAllProduct(Guid? storeID)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();

            param.Add("storeID", storeID);

            dynamic result = _repo.ExecuteProc("Proc_GetAllProduct", param);
            return result;
        }

        /// <summary>
        /// Thêm mới dữ liệu
        /// </summary>
        public override int Insert(ProductEntity item)
        {
            var res = _repo.Insert(item);

            if (res != 0)
            {
                Dictionary<string, object> param = new Dictionary<string, object>();

                param.Add("productID", item.ProductID);

                dynamic result = _repo.ExecuteProc("Proc_AddProductStorage", param);
            }

            return res;
        }
    }
}
