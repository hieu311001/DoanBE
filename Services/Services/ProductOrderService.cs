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
    }
}
