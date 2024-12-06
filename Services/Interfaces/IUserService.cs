using ProductOrder.Entities;

namespace ProductOrder.Services.Interfaces
{
    public interface IUserService : IBaseService<UserEntity>
    {
        dynamic GetUserCustomer();
        dynamic GetUserCustomerByID(string id);
        dynamic GetUserStaff();
    }
}
