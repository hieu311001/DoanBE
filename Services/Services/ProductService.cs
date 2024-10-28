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
    }
}
