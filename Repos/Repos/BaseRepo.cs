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
        public List<T> GetPaging(PagingParameter parameter)
        {
            string query = CommonFunction.BuildSelectQuery<T>(parameter);

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
        public T GetRecord(Guid id)
        {
            string query = CommonFunction.BuildSelectRecordQuery<T>(id);

            var cmd = new MySqlCommand(query, sqlConnection);

            T result = sqlConnection.QueryFirstOrDefault<T>(query);

            if (sqlConnection != null && sqlConnection.State != System.Data.ConnectionState.Closed)
            {
                sqlConnection.Close();
            }

            return result;
        }

        /// <summary>
        /// Thêm mới dữ liệu
        /// </summary>
        public int Insert(T item)
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
        /// Thêm mới nhiều dữ liệu
        /// </summary>
        public int MultiInsert(List<T> items)
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
        public int Update(T item)
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
        public int MultiUpdate(List<T> items)
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
        /// <param name="ids"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int Delete(List<string> ids)
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
    }
}
