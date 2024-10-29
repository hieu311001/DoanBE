namespace ProductOrder.Attributes
{
    public class TableAttribute : Attribute
    {
        /// <summary>
        /// Tên bảng
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Tên view
        /// </summary>
        public string View {  get; set; }
    }
}
