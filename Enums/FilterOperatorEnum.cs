namespace ProductOrder.Enums
{
    public enum FilterOperatorEnum
    {
        /// <summary>
        /// Bằng
        /// </summary>
        Equal = 1,
        
        /// <summary>
        /// Không bằng
        /// </summary>
        NotEqual = 2,

        /// <summary>
        /// Lớn hơn
        /// </summary>
        GreaterThan = 3,

        /// <summary>
        /// Lớn hơn hoặc bằng
        /// </summary>
        GreaterThanOrEqual = 4,

        /// <summary>
        /// Nhỏ hơn
        /// </summary>
        LessThan = 5,

        /// <summary>
        /// Nhỏ hơn hoặc bằng
        /// </summary>
        LessThanOrEqual = 6,

        /// <summary>
        /// Là giá trị NULL
        /// </summary>
        IsNull = 7,

        /// <summary>
        /// Không là giá trị NULL
        /// </summary>
        IsNotNull = 8,

        /// <summary>
        /// Bắt đầu bằng
        /// </summary>
        StartWith = 9,

        /// <summary>
        /// Kết thúc bằng
        /// </summary>
        EndWith = 10,

        /// <summary>
        /// Chứa
        /// </summary>
        Contains = 11,
    }
}
