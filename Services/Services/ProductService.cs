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
    }
}
