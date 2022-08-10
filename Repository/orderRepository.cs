using Dapper;
using DapperUsingWebApi_shaurya.context;
using DapperUsingWebApi_shaurya.model;
using DapperUsingWebApi_shaurya.Repository.Interface;

namespace DapperUsingWebApi_shaurya.Repository
{
    public class orderRepository : IorderRepository
    {
        private readonly DapperContext _context;
        public orderRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<order>> GetOrders()          //awiat can not use within async
        {
            var query = "SELECT * FROM D_order";
            using (var connection = _context.CreateConnection())
            {
                var d_order = await connection.QueryAsync<order>(query);
                return d_order.ToList();
            }
        }

        public async Task<order> GetOrderById(int id)
        {
            var query = "SELECT * FROM D_order where Id=@id";
            using (var connection = _context.CreateConnection())
            {
                var d_order = await connection.QueryAsync<order>(query, new { id = id });
                return d_order.FirstOrDefault();
            }
        }

        public async Task<int> Createorder(order.orderForCreationDto order)
        {
            int result = 0;
            var query = @"INSERT INTO D_order (ordercode,customername,mobilenumber,shippingaddress,billingaddress,totalorderamt) 
                          VALUES (@ordercode,@customername,@mobilenumber,@shippingaddress,@billingaddress,@totalorderamt);
                          SELECT CAST(SCOPE_IDENTITY() as int)";

            using (var connection = _context.CreateConnection())
            {
                result = await connection.QuerySingleAsync<int>(query, order);
                return result;
            }
        }  
        public async Task<int> Updateorder(order.orderForUpdateDto order)
        {
            int result = 0;
            var query = @"UPDATE D_order SET ordercode=@ordercode,customername=@customername,mobilenumber=@mobilenumber,shippingaddress=@shippingaddress,billingaddress=@billingaddress,totalorderamt=@totalorderamt
                          WHERE Id=@Id";

            using (var connection = _context.CreateConnection())
            {
                result = await connection.ExecuteAsync(query, order);
                return result;
            }
        }
        public async Task<int> Deleteorder(int id)
        {
            int result = 0;
            var query = @"Delete from D_order WHERE Id=@id";
            using (var connection = _context.CreateConnection())
            {
                result = await connection.ExecuteAsync(query, new { id = id });
                return result;
            }
        }

    }
}
