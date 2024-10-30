using ProductOrder.Entities;
using ProductOrder.Repos.Interfaces;
using ProductOrder.Services.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace ProductOrder.Services.Services
{
    public class UserService : BaseService<UserEntity, IUserRepo>, IUserService
    {
        public UserService(IUserRepo repo) : base(repo)
        {
        }

        /// <summary>
        /// Xử lý thêm sự kiện thêm người dùng
        /// Hash password
        /// </summary>
        public override int Insert(UserEntity item)
        {
            byte[] bytes = ASCIIEncoding.ASCII.GetBytes(item.Password);

            byte[] hashPassword = MD5.Create().ComputeHash(bytes);

            int i;
            StringBuilder sOutput = new StringBuilder(hashPassword.Length);
            for (i = 0; i < hashPassword.Length; i++)
            {
                sOutput.Append(hashPassword[i].ToString("X2"));
            }
            item.Password = sOutput.ToString();

            return base.Insert(item);
        }
    }
}
