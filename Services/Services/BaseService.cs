using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto;
using ProductOrder.Parameters;
using ProductOrder.Repos.Interfaces;
using ProductOrder.Services.Interfaces;

namespace ProductOrder.Services.Services
{
    public class BaseService<T, TRepo> : IBaseService<T>
        where T : class
        where TRepo : IBaseRepo<T>
    {
        protected TRepo _repo;

        public BaseService(TRepo repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Lấy dữ liệu phân trang
        /// </summary>
        public virtual List<T> GetPaging(PagingParameter parameter)
        {
            return _repo.GetPaging(parameter);
        }

        /// <summary>
        /// Lấy filter
        /// </summary>
        public virtual List<T> GetFilter(List<FilterParameter> filters, List<string> columns)
        {
            return _repo.GetFilter(filters, columns);
        }

        /// <summary>
        /// Lấy 1 bản ghi
        /// </summary>
        public virtual dynamic GetRecord(Guid id)
        {
            return _repo.GetRecord(id);
        }

        /// <summary>
        /// Thêm mới dữ liệu
        /// </summary>
        public virtual int Insert(T item)
        {
            return _repo.Insert(item);
        }

        /// <summary>
        /// Thêm mới nhiều dữ liệu
        /// </summary>
        public virtual int MultiInsert(List<T> items)
        {
            return _repo.MultiInsert(items);
        }

        /// <summary>
        /// Cập nhật dữ liệu
        /// </summary>
        public virtual int Update(T item)
        {
            return _repo.Update(item);
        }

        /// <summary>
        /// Cập nhật nhiều dữ liệu
        /// </summary>
        public virtual int MultiUpdate(List<T> items)
        {
            return _repo.MultiUpdate(items);
        }

        /// <summary>
        /// Xóa nhiều bản ghi
        /// </summary>
        public virtual int Delete(List<string> ids)
        {
            return _repo.Delete(ids);
        }

        public dynamic GetAll()
        {
            return _repo.GetAll();
        }
    }
}
