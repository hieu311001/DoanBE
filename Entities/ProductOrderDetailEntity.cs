using ProductOrder.Attributes;

namespace ProductOrder.Entities
{
    /// <summary>
    /// Bảng chi tiết đơn hàng
    /// </summary>
    [Table(Name = "productorderdetails", View = "view_productorderdetails")]
    public class ProductOrderDetailEntity
    {
        [Key]
        public Guid ProductOrderDetailID { get; set; }

        /// <summary>
        /// ID đơn hàng
        /// </summary>
        public Guid ProductOrderID { get; set; }

        /// <summary>
        /// ID sản phẩm
        /// </summary>
        public Guid ProductID { get; set; }

        /// <summary>
        /// Số lượng được đặt
        /// </summary>
        public int? Amount { get; set; }

        /// <summary>
        /// Đơn giá
        /// </summary>
        public decimal? Price { get; set; }
    }
}
