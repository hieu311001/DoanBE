using ProductOrder.Entities;
using ProductOrder.Repos.Interfaces;

namespace ProductOrder.Repos.Repos
{
    public class ProductStorageRepo : BaseRepo<ProductStorageEntity>, IProductStorageRepo
    {
        public ProductStorageRepo(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
