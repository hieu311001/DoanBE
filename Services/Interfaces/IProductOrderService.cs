using ProductOrder.Entities;
using ProductOrder.Parameters;

namespace ProductOrder.Services.Interfaces
{
    public interface IProductOrderService : IBaseService<ProductOrderEntity>
    {
        bool CreateOrder(CreateOrderParam param);
    }
}
