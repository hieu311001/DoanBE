using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductOrder.Entities;
using ProductOrder.Model;
using ProductOrder.Parameters;
using ProductOrder.Services.Interfaces;

namespace ProductOrder.Controllers
{
    [ApiController]
    public class UserController : BaseController<UserEntity, IUserService>
    {
        private IAuthService _authService;

        public UserController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _authService = serviceProvider.GetRequiredService<IAuthService>();
        }

        /// <summary>
        /// Đăng nhập
        /// </summary>
        [HttpPost("login")]
        public IActionResult Login(LoginParameter parameter)
        {
            ModelUserLogin result = _authService.Login(parameter);

            return Ok(result);
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            return Ok();
        }

        [HttpGet("staff")]
        public IActionResult GetUserStaff()
        {
            dynamic result = _service.GetUserStaff();
            return Ok(result);
        }

        [HttpGet("customer")]
        public IActionResult GetUserCustomer()
        {
            dynamic result = _service.GetUserCustomer();
            return Ok(result);
        }

        [HttpGet("customer/{id}")]
        public IActionResult GetUserCustomerByID(string id)
        {
            dynamic result = _service.GetUserCustomerByID(id);
            return Ok(result);
        }
    }
}
