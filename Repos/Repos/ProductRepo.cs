using Dapper;
using MySqlConnector;
using ProductOrder.Entities;
using ProductOrder.Functions;
using ProductOrder.Repos.Interfaces;

namespace ProductOrder.Repos.Repos
{
    public class ProductRepo : BaseRepo<ProductEntity>, IProductRepo
    {
        public ProductRepo(IConfiguration configuration) : base(configuration)
        {
        }

        /// <summary>
        /// Lấy 1 bản ghi
        /// </summary>
        public dynamic GetRecord(Guid id)
        {
            string query = CommonFunction.BuildSelectRecordQuery<ProductEntity>(id);

            var cmd = new MySqlCommand(query, sqlConnection);

            dynamic result = sqlConnection.QueryFirstOrDefault<dynamic>(query);

            if (sqlConnection != null && sqlConnection.State != System.Data.ConnectionState.Closed)
            {
                sqlConnection.Close();
            }

            return result;
        }
    }
}
