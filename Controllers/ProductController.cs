using Microsoft.AspNetCore.Mvc;
using ProductOrder.Entities;
using ProductOrder.Parameters;
using ProductOrder.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductOrder.Controllers
{
    [ApiController]
    public class ProductController : BaseController<ProductEntity, IProductService>
    {
        public ProductController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        /// <summary>
        /// Lấy toàn bộ sản phẩm
        /// </summary>
        [HttpGet("get-all/{storeID}")]
        public IActionResult GetAllProduct(Guid? storeID)
        {
            dynamic result = _service.GetAllProduct(storeID);
            return Ok(result);
        }
    }
}
