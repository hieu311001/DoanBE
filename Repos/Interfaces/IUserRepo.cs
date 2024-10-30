using ProductOrder.Entities;
using ProductOrder.Parameters;

namespace ProductOrder.Repos.Interfaces
{
    public interface IUserRepo : IBaseRepo<UserEntity>
    {
        /// <summary>
        /// Lấy thông tin user từ tài khoản, mật khẩu
        /// </summary>
        UserEntity GetUserLogin(string userName);
    }
}
