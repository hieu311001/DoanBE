using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductOrder.Entities;
using ProductOrder.Parameters;
using ProductOrder.Services.Interfaces;

namespace ProductOrder.Controllers
{
    [ApiController]
    public class StoreController : BaseController<StoreEntity, IStoreService>
    {
        public StoreController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        /// <summary>
        /// Lấy toàn bộ sản phẩm
        /// </summary>
        [HttpGet("get-report/{isMonth}")]
        public IActionResult GetStoreReport(Boolean isMonth)
        {
            dynamic result = _service.GetStoreReport(isMonth);
            return Ok(result);
        }

        /// <summary>
        /// Lấy toàn bộ sản phẩm
        /// </summary>
        [HttpGet("get-report-storage/{isMonth}")]
        public IActionResult GetStorageReport(Boolean isMonth)
        {
            dynamic result = _service.GetStorageReport(isMonth);
            return Ok(result);
        }
    }
}
