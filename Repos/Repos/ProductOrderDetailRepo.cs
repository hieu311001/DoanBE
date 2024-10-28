using ProductOrder.Entities;
using ProductOrder.Repos.Interfaces;

namespace ProductOrder.Repos.Repos
{
    public class ProductOrderDetailRepo : BaseRepo<ProductOrderDetailEntity>, IProductOrderDetailRepo
    {
        public ProductOrderDetailRepo(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
