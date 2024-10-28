using ProductOrder.Entities;
using ProductOrder.Repos.Interfaces;
using ProductOrder.Services.Interfaces;

namespace ProductOrder.Services.Services
{
    public class ProductOrderService : BaseService<ProductOrderEntity, IProductOrderRepo>, IProductOrderService
    {
        public ProductOrderService(IProductOrderRepo repo) : base(repo)
        {
        }
    }
}
