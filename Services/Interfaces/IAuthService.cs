using ProductOrder.Entities;
using ProductOrder.Model;
using ProductOrder.Parameters;

namespace ProductOrder.Services.Interfaces
{
    public interface IAuthService
    {
        /// <summary>
        /// Xử lý đăng nhập
        /// </summary>
        ModelUserLogin Login(LoginParameter parameter);
    }
}
