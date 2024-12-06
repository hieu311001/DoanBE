using ProductOrder.Entities;
using ProductOrder.Parameters;
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

        public dynamic GetUserCustomer()
        {
            return _repo.ExecuteProc("Proc_GetUserCustomer", null);
        }

        public dynamic GetUserCustomerByID(string id)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();

            param.Add("userID", id);

            return _repo.ExecuteProc("Proc_GetUserCustomerByID", param);
        }

        public dynamic GetUserStaff()
        {
            return _repo.ExecuteProc("Proc_GetUserStaff", null);
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

        /// <summary>
        /// Xử lý thêm sự kiện thêm nhiều người dùng
        /// Hash password
        /// </summary>
        public override int MultiInsert(List<UserEntity> items)
        {
            foreach(UserEntity item in items)
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
            }

            return base.MultiInsert(items);
        }
    }
}
