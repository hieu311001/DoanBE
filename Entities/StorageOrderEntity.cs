using ProductOrder.Attributes;
using ProductOrder.Enums;

namespace ProductOrder.Entities
{
    /// <summary>
    /// Bảng yêu cầu lấy hàng từ kho
    /// </summary>
    [Table(Name = "storageorders", View = "view_storageorder")]
    public class StorageOrderEntity
    {
        [Key]
        public Guid StorageOrderID { get; set; }

        /// <summary>
        /// ID cửa hàng
        /// </summary>
        public Guid StoreID { get; set; }

        /// <summary>
        /// Trạng thái
        /// </summary>
        public StorageOrderStatus Status { get; set; }

        public DateTime? CreateDate { get; set; }

        public string Note { get; set; }

        public string Reject {  get; set; }
    }
}
