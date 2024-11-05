using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductOrder.Entities;
using ProductOrder.Parameters;
using ProductOrder.Services.Interfaces;

namespace ProductOrder.Controllers
{
    [ApiController]
    public class ProductOrderController : BaseController<ProductOrderEntity, IProductOrderService>
    {
        public ProductOrderController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        /// <summary>
        /// Tạo đơn hàng
        /// </summary>
        [HttpPost("order")]
        public IActionResult CreateOrder([FromBody] CreateOrderParam param)
        {
            var result = _service.CreateOrder(param);
            return Ok(result);
        }
    }
}
