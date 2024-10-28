using ProductOrder.Entities;
using ProductOrder.Repos.Interfaces;

namespace ProductOrder.Repos.Repos
{
    public class ProductRepo : BaseRepo<ProductEntity>, IProductRepo
    {
        public ProductRepo(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
