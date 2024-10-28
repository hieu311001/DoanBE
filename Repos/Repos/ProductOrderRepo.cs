using ProductOrder.Entities;
using ProductOrder.Repos.Interfaces;

namespace ProductOrder.Repos.Repos
{
    public class ProductOrderRepo : BaseRepo<ProductOrderEntity>, IProductOrderRepo
    {
        public ProductOrderRepo(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
