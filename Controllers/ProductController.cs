using Microsoft.AspNetCore.Mvc;
using ProductOrder.Entities;
using ProductOrder.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductOrder.Controllers
{
    [ApiController]
    public class ProductController : BaseController<ProductEntity, IProductService>
    {
        public ProductController(IProductService service) : base(service)
        {
        }
    }
}
