using ProductOrder.Entities;
using ProductOrder.Parameters;

namespace ProductOrder.Services.Interfaces
{
    public interface IProductService : IBaseService<ProductEntity>
    {
        dynamic GetAllProduct(Guid? storeID);
    }
}
