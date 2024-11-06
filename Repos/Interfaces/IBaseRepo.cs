using ProductOrder.Parameters;

namespace ProductOrder.Repos.Interfaces
{
    public interface IBaseRepo<T> where T : class
    {
        /// <summary>
        /// Lấy dữ liệu phân trang
        /// </summary>
        List<T> GetPaging(PagingParameter parameter);

        /// <summary>
        /// Lấy filter
        /// </summary>
        List<T> GetFilter(List<FilterParameter> filters, List<string> columns);

        /// <summary>
        /// Lấy 1 bản ghi
        /// </summary>
        dynamic GetRecord(Guid id);

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
        /// Xóa nhiều dữ liệu
        /// </summary>
        int Delete(List<string> ids);

        dynamic ExecuteProc(string procName, Dictionary<string, object> parameters);
        dynamic GetAll();
    }
}
