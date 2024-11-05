using Dapper;
using MySqlConnector;
using ProductOrder.Entities;
using ProductOrder.Functions;
using ProductOrder.Parameters;
using ProductOrder.Repos.Interfaces;

namespace ProductOrder.Repos.Repos
{
    public class ProductOrderRepo : BaseRepo<ProductOrderEntity>, IProductOrderRepo
    {
        public ProductOrderRepo(IConfiguration configuration) : base(configuration)
        {
        }

        public bool CreateOrder(CreateOrderParam param)
        {
            using (var transaction = sqlConnection.BeginTransaction())
            {
                try
                {
                    ProductOrderEntity master = param.productOrder;
                    List<ProductOrderDetailEntity> details = param.productOrderDetails;

                    int s1 = Insert(master, transaction);

                    if (s1 == 0)
                    {
                        transaction.Rollback();
                        return false;
                    }

                    int s2 = MultiInsertDetails(details, transaction);

                    if (s2 == 0)
                    {
                        transaction.Rollback();
                        return false;
                    }

                    // Commit transaction
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return false;
                }
                finally
                {
                    if (sqlConnection != null && sqlConnection.State != System.Data.ConnectionState.Closed)
                    {
                        sqlConnection.Close();
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Thêm mới nhiều dữ liệu với transaction truyền vào
        /// </summary>
        public virtual int MultiInsertDetails(List<ProductOrderDetailEntity> items, MySqlTransaction transaction)
        {
            int row = 0;

            try
            {
                foreach (ProductOrderDetailEntity item in items)
                {
                    string query = CommonFunction.BuildInsertQuery<ProductOrderDetailEntity>(item);

                    int result = sqlConnection.Execute(query, transaction: transaction);

                    row += result;
                }
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw;
            }

            return row;
        }
    }
}
