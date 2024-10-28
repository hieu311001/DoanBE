using ProductOrder.Attributes;

namespace ProductOrder.Entities
{
    /// <summary>
    /// Bảng chi tiết yêu cầu đặt hàng từ kho
    /// </summary>
    [Table(Name = "storageorderdetails")]
    public class StorageOrderDetailEntity
    {
        [Key]
        public Guid StorageOrderDetailID { get; set; }

        /// <summary>
        /// ID yêu cầu
        /// </summary>
        public Guid StorageOrderID { get; set; }

        /// <summary>
        /// ID sản phẩm
        /// </summary>
        public Guid ProductID { get; set; }

        /// <summary>
        /// Số lượng đặt
        /// </summary>
        public int? Amount { get; set; }
    }
}
