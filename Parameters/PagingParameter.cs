namespace ProductOrder.Parameters
{
    public class PagingParameter
    {
        /// <summary>
        /// Số trang
        /// </summary>
        public int Skip { get; set; }

        /// <summary>
        /// Số bản ghi trên một trang
        /// </summary>
        public int Take { get; set; }

        /// <summary>
        /// Tham số lọc
        /// </summary>
        public List<FilterParameter> Filters { get; set; }

        /// <summary>
        /// Cột được lấy
        /// </summary>
        public List<string> Columns { get; set; }
    }
}
