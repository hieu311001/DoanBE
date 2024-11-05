using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductOrder.Entities;
using ProductOrder.Parameters;
using ProductOrder.Services.Interfaces;

namespace ProductOrder.Controllers
{
    [ApiController]
    public class StorageOrderController : BaseController<StorageOrderEntity, IStorageOrderService>
    {
        public StorageOrderController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        /// <summary>
        /// Tạo yêu cầu nhập hàng
        /// </summary>
        [HttpPost("store-order")]
        public IActionResult CreateStoreOrder([FromBody] CreateStoreOrderParam param)
        {
            var result = _service.CreateStoreOrder(param);
            return Ok(result);
        }
    }
}
