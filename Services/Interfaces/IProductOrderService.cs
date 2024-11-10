using ProductOrder.Entities;
using ProductOrder.Parameters;

namespace ProductOrder.Services.Interfaces
{
    public interface IProductOrderService : IBaseService<ProductOrderEntity>
    {
        bool CreateOrder(CreateOrderParam param);
        dynamic GetAllProductOrder(Guid? storeID);
        dynamic GetProductByProductOrder(Guid? productOrderID);
        dynamic GetProductOrderByUserID(Guid? userID);
    }
}
