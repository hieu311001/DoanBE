using ProductOrder.Attributes;

namespace ProductOrder.Entities
{
    /// <summary>
    /// Bảng sản phẩm
    /// </summary>
    [Table(Name = "products", View = "view_productdetails")]
    public class ProductEntity
    {
        [Key]
        public Guid ProductID { get; set; }

        /// <summary>
        /// Tên
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Hình ảnh
        /// </summary>
        public string Image {  get; set; }

        /// <summary>
        /// Giá tiền
        /// </summary>
        public decimal? Price { get; set; }
        /// <summary>
        /// Giá gốc
        /// </summary>
        public decimal? OriginalPrice { get; set; }

        /// <summary>
        /// Thương hiệu
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// Danh mục
        /// </summary>
        public int? ProductCategory { get; set; }

        /// <summary>
        /// Giảm giá
        /// </summary>
        public decimal? Sale { get; set; }

        /// <summary>
        /// Mô tả
        /// </summary>
        public string Description { get; set; }
    }
}
