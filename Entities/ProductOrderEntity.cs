using ProductOrder.Attributes;
using ProductOrder.Enums;

namespace ProductOrder.Entities
{
    /// <summary>
    /// Bảng đơn hàng
    /// </summary>
    [Table(Name = "productorders", View = "view_productorders")]
    public class ProductOrderEntity
    {
        [Key]
        public Guid ProductOrderID { get; set; }

        /// <summary>
        /// ID người dùng
        /// </summary>
        public Guid? UserID { get; set; }

        /// <summary>
        /// Họ tên
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// SĐT
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Địa chỉ
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Tổng giá
        /// </summary>
        public decimal? TotalPrice { get; set; }

        /// <summary>
        /// Phương thức thanh toán
        /// </summary>
        public PaymentMethod PaymentMethod { get; set; }

        /// <summary>
        /// ID cửa hàng
        /// </summary>
        public Guid StoreID { get; set; }

        /// <summary>
        /// Ngày đặt hàng
        /// </summary>
        public DateTime? OrderDate { get; set; }

        /// <summary>
        /// Trạng thái
        /// </summary>
        public ProductOrderStatus Status { get; set; }
    }
}
