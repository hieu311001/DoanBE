using ProductOrder.Entities;
using ProductOrder.Repos.Interfaces;
using ProductOrder.Services.Interfaces;

namespace ProductOrder.Services.Services
{
    public class ProductStorageService : BaseService<ProductStorageEntity, IProductStorageRepo>, IProductStorageService
    {
        public ProductStorageService(IProductStorageRepo repo) : base(repo)
        {
        }
    }
}
