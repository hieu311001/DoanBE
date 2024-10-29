using ProductOrder.Attributes;

namespace ProductOrder.Entities
{
    /// <summary>
    /// Bảng cửa hàng
    /// </summary>
    [Table(Name = "stores")]
    public class StoreEntity
    {
        [Key]
        public Guid StoreID { get; set; }

        /// <summary>
        /// Tên cửa hàng
        /// </summary>
        public string StoreName { get; set; }

        /// <summary>
        /// Địa chỉ
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// SĐT
        /// </summary>
        public string PhoneNumber { get; set; }
    }
}
