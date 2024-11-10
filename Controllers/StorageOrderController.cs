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

        /// <summary>
        /// Tạo yêu cầu nhập hàng
        /// </summary>
        [HttpPost("store-order-storage")]
        public IActionResult CreateStoreOrderByStorage([FromBody] CreateStoreOrderParam param)
        {
            var result = _service.CreateStoreOrderByStorage(param);
            return Ok(result);
        }


        /// <summary>
        /// Lấy toàn bộ sản phẩm
        /// </summary>
        [HttpGet("get-detail/{storageOrderID}")]
        public IActionResult GetProductByStorageOrder(Guid? storageOrderID)
        {
            dynamic result = _service.GetProductByStorageOrder(storageOrderID);
            return Ok(result);
        }

        /// <summary>
        /// Lấy toàn bộ sản phẩm
        /// </summary>
        [HttpPut("accept")]
        public IActionResult AcceptStorageOrder([FromBody] AcceptStorageOrderParam param)
        {
            dynamic result = _service.AcceptStorageOrder(param.StorageOrderID);
            return Ok(result);
        }

        /// <summary>
        /// Lấy toàn bộ sản phẩm
        /// </summary>
        [HttpGet("{storeID}")]
        public IActionResult GetAllStorageOrderByStorage(Guid storeID)
        {
            dynamic result = _service.GetAllStorageOrderByStorage(storeID);
            return Ok(result);
        }
    }
}
