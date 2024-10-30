using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductOrder.Entities;
using ProductOrder.Services.Interfaces;

namespace ProductOrder.Controllers
{
    [ApiController]
    public class ProductOrderDetailController : BaseController<ProductOrderDetailEntity, IProductOrderDetailService>
    {
        public ProductOrderDetailController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
    }
}
