using ProductOrder.Entities;
using ProductOrder.Repos.Interfaces;
using ProductOrder.Services.Interfaces;

namespace ProductOrder.Services.Services
{
    public class ProductOrderDetailService : BaseService<ProductOrderDetailEntity, IProductOrderDetailRepo>, IProductOrderDetailService
    {
        public ProductOrderDetailService(IProductOrderDetailRepo repo) : base(repo)
        {
        }
    }
}
