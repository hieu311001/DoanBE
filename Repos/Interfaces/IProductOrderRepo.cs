using ProductOrder.Entities;
using ProductOrder.Parameters;

namespace ProductOrder.Repos.Interfaces
{
    public interface IProductOrderRepo : IBaseRepo<ProductOrderEntity>
    {
        bool CreateOrder(CreateOrderParam param);
    }
}
