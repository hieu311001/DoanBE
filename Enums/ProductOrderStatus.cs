namespace ProductOrder.Enums
{
    /// <summary>
    /// Trạng thái đơn hàng
    /// </summary>
    public enum ProductOrderStatus
    {
        /// <summary>
        /// Đang xử lý
        /// </summary>
        Processing = 0,

        /// <summary>
        /// Đang giao hàng
        /// </summary>
        Incoming = 1,

        /// <summary>
        /// Đã hoàn thành
        /// </summary>
        Done = 2,

        /// <summary>
        /// Hủy
        /// </summary>
        Cancel = 3
    }
}
