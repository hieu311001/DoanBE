using Microsoft.AspNetCore.Mvc;
using ProductOrder.Parameters;
using ProductOrder.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductOrder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T, TService> : ControllerBase
        where T : class
        where TService : IBaseService<T>
    {
        TService _service;

        public BaseController(TService service)
        {
            _service = service;
        }

        /// <summary>
        /// Lấy phân trang
        /// </summary>
        [HttpPost("paging")]
        public IActionResult GetPaging([FromBody] PagingParameter parameter)
        {
            List<T> result = _service.GetPaging(parameter);
            return Ok(result);
        }

        /// <summary>
        /// Lấy bản ghi
        /// </summary>
        [HttpGet("id")]
        public IActionResult GetRecord(Guid id)
        {
            T result = _service.GetRecord(id);

            return Ok(result);
        }

        /// <summary>
        /// Thêm mới
        /// </summary>
        [HttpPost]
        public IActionResult Insert([FromBody] T item)
        {
            int result = _service.Insert(item);
            return Ok(result);
        }

        /// <summary>
        /// Thêm mới nhiều
        /// </summary>
        [HttpPost("multi")]
        public IActionResult MultiInsert([FromBody] List<T> items)
        {
            int result = _service.MultiInsert(items);
            return Ok(result);
        }

        /// <summary>
        /// Cập nhật
        /// </summary>
        [HttpPut]
        public IActionResult Update([FromBody] T item)
        {
            int result = _service.Update(item);
            return Ok(result);
        }

        /// <summary>
        /// Cập nhật nhiều
        /// </summary>
        [HttpPut("multi")]
        public IActionResult MultiUpdate([FromBody] List<T> items)
        {
            int result = _service.MultiUpdate(items);
            return Ok(result);
        }

        /// <summary>
        /// Xóa
        /// </summary>
        [HttpDelete]
        public IActionResult Delete([FromBody] List<string> ids)
        {
            int result = _service.Delete(ids);
            return Ok(result);
        }
    }
}
