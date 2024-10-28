namespace ProductOrder.Enums
{
    /// <summary>
    /// Vai trò người dùng
    /// </summary>
    public enum Role
    {
        /// <summary>
        /// Quản lý
        /// </summary>
        Admin = 0,

        /// <summary>
        /// Nhân viên
        /// </summary>
        Staff = 1,

        /// <summary>
        /// Nhân viên kho
        /// </summary>
        StorageStaff = 2,

        /// <summary>
        /// Khách hàng
        /// </summary>
        Customer = 3,
    }
}
