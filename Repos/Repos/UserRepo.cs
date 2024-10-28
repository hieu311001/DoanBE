using ProductOrder.Entities;
using ProductOrder.Repos.Interfaces;

namespace ProductOrder.Repos.Repos
{
    public class UserRepo : BaseRepo<UserEntity>, IUserRepo
    {
        public UserRepo(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
