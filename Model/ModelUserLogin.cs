using ProductOrder.Attributes;
using ProductOrder.Enums;

namespace ProductOrder.Model
{
    public class ModelUserLogin
    {
        [Key]
        public Guid UserID { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Họ tên
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// SĐT
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Vai trò
        /// </summary>
        public Role Role { get; set; }

        /// <summary>
        /// ID cửa hàng
        /// </summary>
        public Guid? StoreID { get; set; }

        /// <summary>
        /// Access token
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// Access token
        /// </summary>
        public string Address { get; set; }
    }
}
