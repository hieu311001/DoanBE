using ProductOrder.Enums;

namespace ProductOrder.Parameters
{
    public class FilterParameter
    {
        /// <summary>
        /// Phép toán lọc
        /// </summary>
        public FilterOperatorEnum Operator { get; set; }

        /// <summary>
        /// Cột lọc
        /// </summary>
        public string Column {  get; set; }

        /// <summary>
        /// Giá trị lọc
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// Lọc hoặc
        /// </summary>
        public List<FilterParameter> Ors { get; set; }
    }
}
