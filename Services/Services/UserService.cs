using ProductOrder.Entities;
using ProductOrder.Repos.Interfaces;
using ProductOrder.Services.Interfaces;

namespace ProductOrder.Services.Services
{
    public class UserService : BaseService<UserEntity, IUserRepo>, IUserService
    {
        public UserService(IUserRepo repo) : base(repo)
        {
        }
    }
}
