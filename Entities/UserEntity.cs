using Microsoft.AspNetCore.Identity;
using ProductOrder.Attributes;
using ProductOrder.Enums;

namespace ProductOrder.Entities
{
    /// <summary>
    /// Người dùng
    /// </summary>
    [Table(Name = "users")]
    public class UserEntity
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
        /// Mật khẩu
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Địa chỉ
        /// </summary>
        public string Address { get; set; }
    }
}
