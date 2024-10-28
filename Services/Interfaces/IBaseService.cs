using ProductOrder.Parameters;

namespace ProductOrder.Services.Interfaces
{
    public interface IBaseService<T> where T : class
    {
        /// <summary>
        /// Lấy phân trang
        /// </summary>
        /// <returns></returns>
        List<T> GetPaging(PagingParameter parameter);

        /// <summary>
        /// Lấy 1 bản ghi
        /// </summary>
        T GetRecord(Guid id);

        /// <summary>
        /// Thêm mới dữ liệu
        /// </summary>
        int Insert(T item);

        /// <summary>
        /// Thêm mới nhiều dữ liệu
        /// </summary>
        int MultiInsert(List<T> items);

        /// <summary>
        /// Cập nhật dữ liệu
        /// </summary>
        int Update(T item);

        /// <summary>
        /// Cập nhật nhiều dữ liệu
        /// </summary>
        int MultiUpdate(List<T> items);

        /// <summary>
        /// Xóa nhiều bản ghi
        /// </summary>
        int Delete(List<string> ids);
    }
}
