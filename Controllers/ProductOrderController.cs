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

        /// <summary>
        /// Lấy toàn bộ sản phẩm
        /// </summary>
        [HttpGet("get-all/{storeID}")]
        public IActionResult GetAllProductOrder(Guid? storeID)
        {
            dynamic result = _service.GetAllProductOrder(storeID);
            return Ok(result);
        }

        /// <summary>
        /// Lấy toàn bộ sản phẩm
        /// </summary>
        [HttpGet("get-by-user/{userID}")]
        public IActionResult GetProductOrderByUserID(Guid? userID)
        {
            dynamic result = _service.GetProductOrderByUserID(userID);
            return Ok(result);
        }

        /// <summary>
        /// Lấy toàn bộ sản phẩm
        /// </summary>
        [HttpGet("get-detail/{productOrderID}")]
        public IActionResult GetProductByProductOrder(Guid? productOrderID)
        {
            dynamic result = _service.GetProductByProductOrder(productOrderID);
            return Ok(result);
        }
    }
}
