using Dapper;
using MySqlConnector;
using ProductOrder.Functions;
using ProductOrder.Parameters;
using ProductOrder.Repos.Interfaces;

namespace ProductOrder.Repos.Repos
{
    public class BaseRepo<T> : IBaseRepo<T> where T : class
    {
        public MySqlConnection sqlConnection;

        public BaseRepo(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            sqlConnection = new MySqlConnection(connectionString);

            if (sqlConnection != null && sqlConnection.State != System.Data.ConnectionState.Open)
            {
                sqlConnection.Open();
            }
        }

        /// <summary>
        /// Lấy dữ liệu phân trang
        /// </summary>
        public virtual List<T> GetPaging(PagingParameter parameter)
        {
            string query = CommonFunction.BuildSelectPagingQuery<T>(parameter);

            var cmd = new MySqlCommand(query, sqlConnection);

            List<T> result = sqlConnection.Query<T>(query).ToList();

            if (sqlConnection != null && sqlConnection.State != System.Data.ConnectionState.Closed)
            {
                sqlConnection.Close();
            }

            return result;
        }

        /// <summary>
        /// Lấy filter
        /// </summary>
        public virtual List<T> GetFilter(List<FilterParameter> filters, List<string> columns)
        {
            string query = CommonFunction.BuildSelectFilterQuery<T>(filters, columns);

            var cmd = new MySqlCommand(query, sqlConnection);

            List<T> result = sqlConnection.Query<T>(query).ToList();

            if (sqlConnection != null && sqlConnection.State != System.Data.ConnectionState.Closed)
            {
                sqlConnection.Close();
            }

            return result;
        }

        /// <summary>
        /// Lấy 1 bản ghi
        /// </summary>
        public virtual dynamic GetRecord(Guid id)
        {
            string query = CommonFunction.BuildSelectRecordQuery<T>(id);

            var cmd = new MySqlCommand(query, sqlConnection);

            dynamic result = sqlConnection.QueryFirstOrDefault<T>(query);

            if (sqlConnection != null && sqlConnection.State != System.Data.ConnectionState.Closed)
            {
                sqlConnection.Close();
            }

            return result;
        }

        /// <summary>
        /// Thêm mới dữ liệu
        /// </summary>
        public virtual int Insert(T item)
        {
            string query = CommonFunction.BuildInsertQuery<T>(item);

            var cmd = new MySqlCommand(query, sqlConnection);

            int result = sqlConnection.Execute(query);

            if (sqlConnection != null && sqlConnection.State != System.Data.ConnectionState.Closed)
            {
                sqlConnection.Close();
            }

            return result;
        }

        /// <summary>
        /// Thêm mới dữ liệu với transaction truyền vào
        /// </summary>
        public virtual int Insert(T item, MySqlTransaction transaction)
        {
            string query = CommonFunction.BuildInsertQuery<T>(item);

            int result = sqlConnection.Execute(query, transaction: transaction);

            return result;
        }

        /// <summary>
        /// Thêm mới nhiều dữ liệu
        /// </summary>
        public virtual int MultiInsert(List<T> items)
        {
            int row = 0;

            using (var transaction = sqlConnection.BeginTransaction())
            {
                try
                {
                    foreach (T item in items)
                    {
                        string query = CommonFunction.BuildInsertQuery<T>(item);

                        var cmd = new MySqlCommand(query, sqlConnection);

                        int result = sqlConnection.Execute(query);

                        row += result;
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
                finally
                {
                    if (sqlConnection != null && sqlConnection.State != System.Data.ConnectionState.Closed)
                    {
                        sqlConnection.Close();
                    }
                }
            }

            return row;
        }

        /// <summary>
        /// Cập nhật dữ liệu
        /// </summary>
        public virtual int Update(T item)
        {
            string query = CommonFunction.BuildUpdateQuery<T>(item);

            var cmd = new MySqlCommand(query, sqlConnection);

            int result = sqlConnection.Execute(query);

            if (sqlConnection != null && sqlConnection.State != System.Data.ConnectionState.Closed)
            {
                sqlConnection.Close();
            }

            return result;
        }

        /// <summary>
        /// Cập nhật nhiều dữ liệu
        /// </summary>
        public virtual int MultiUpdate(List<T> items)
        {
            int row = 0;

            using (var transaction = sqlConnection.BeginTransaction())
            {
                try
                {
                    foreach (T item in items)
                    {
                        string query = CommonFunction.BuildUpdateQuery<T>(item);

                        var cmd = new MySqlCommand(query, sqlConnection);

                        int result = sqlConnection.Execute(query);

                        row += result;
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
                finally
                {
                    if (sqlConnection != null && sqlConnection.State != System.Data.ConnectionState.Closed)
                    {
                        sqlConnection.Close();
                    }
                }
            }

            return row;
        }

        /// <summary>
        /// Xóa nhiều dữ liệu
        /// </summary>
        public virtual int Delete(List<string> ids)
        {
            string query = CommonFunction.BuildDeleteQuery<T>(ids);

            var cmd = new MySqlCommand(query, sqlConnection);

            int result = sqlConnection.Execute(query);

            if (sqlConnection != null && sqlConnection.State != System.Data.ConnectionState.Closed)
            {
                sqlConnection.Close();
            }

            return result;
        }

        /// <summary>
        /// Xử lý gọi proc
        /// </summary>
        public virtual dynamic ExecuteProc(string procName, Dictionary<string, object> parameters)
        {
            var param = new DynamicParameters(parameters);

            dynamic result = sqlConnection.Query(procName, param, commandType: System.Data.CommandType.StoredProcedure);

            if (sqlConnection != null && sqlConnection.State != System.Data.ConnectionState.Closed)
            {
                sqlConnection.Close();
            }

            return result;
        }

        public dynamic GetAll()
        {
            string query = CommonFunction.BuildSelectQuery<T>();

            var cmd = new MySqlCommand(query, sqlConnection);

            dynamic result = sqlConnection.Query<dynamic>(query).ToList();

            if (sqlConnection != null && sqlConnection.State != System.Data.ConnectionState.Closed)
            {
                sqlConnection.Close();
            }

            return result;
        }
    }
}
