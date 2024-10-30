using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductOrder.Entities;
using ProductOrder.Services.Interfaces;

namespace ProductOrder.Controllers
{
    [ApiController]
    public class ProductOrderController : BaseController<ProductOrderEntity, IProductOrderService>
    {
        public ProductOrderController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
    }
}
