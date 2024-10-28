using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductOrder.Entities;
using ProductOrder.Services.Interfaces;

namespace ProductOrder.Controllers
{
    [ApiController]
    public class UserController : BaseController<UserEntity, IUserService>
    {
        public UserController(IUserService service) : base(service)
        {
        }
    }
}
