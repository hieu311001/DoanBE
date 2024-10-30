using ProductOrder.Entities;
using ProductOrder.Parameters;
using ProductOrder.Repos.Interfaces;

namespace ProductOrder.Repos.Repos
{
    public class UserRepo : BaseRepo<UserEntity>, IUserRepo
    {
        public UserRepo(IConfiguration configuration) : base(configuration)
        {
        }

        /// <summary>
        /// Lấy thông tin user từ tài khoản, mật khẩu
        /// </summary>
        public UserEntity GetUserLogin(string userName)
        {
            var filters = new List<FilterParameter>()
            {
                new FilterParameter()
                {
                    Operator = Enums.FilterOperatorEnum.Equal,
                    Value = userName,
                    Column = nameof(UserEntity.Email),
                }
            };

            List<string> columns = typeof(UserEntity).GetProperties()
                                                     .Select(f => f.Name)
                                                     .ToList();

            List<UserEntity> users = GetFilter(filters, columns);

            if (users == null || users.Count == 0)
            {
                return null;
            }

            return users[0];
        }
    }
}
