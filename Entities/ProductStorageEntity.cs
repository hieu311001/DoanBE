using ProductOrder.Attributes;

namespace ProductOrder.Entities
{
    /// <summary>
    /// Bảng kho hàng
    /// </summary>
    [Table(Name = "productstorages", View = "view_productstorages")]
    public class ProductStorageEntity
    {
        [Key]
        public Guid ProductStorageID { get; set; }

        /// <summary>
        /// ID sản phẩm
        /// </summary>
        public Guid ProductID { get; set; }

        /// <summary>
        /// ID cửa hàng
        /// </summary>
        public Guid StoreID { get; set; }

        /// <summary>
        /// Số lượng
        /// </summary>
        public decimal TotalAmount { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
