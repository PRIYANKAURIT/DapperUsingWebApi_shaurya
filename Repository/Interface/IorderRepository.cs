using DapperUsingWebApi_shaurya.model;
using static DapperUsingWebApi_shaurya.model.order;

namespace DapperUsingWebApi_shaurya.Repository.Interface
{
    public interface IorderRepository
    {
        public Task<IEnumerable<order>> GetOrders();
        public Task<order> GetOrderById(int id);
        public Task<int> Createorder(orderForCreationDto order);
        public Task<int> Updateorder(orderForUpdateDto order);    
        public Task<int> Deleteorder(int id);
    }
}
