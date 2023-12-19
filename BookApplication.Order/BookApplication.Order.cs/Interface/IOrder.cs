using BookApplication.Order.cs.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookApplication.Order.cs.Interface
{
    public interface IOrder
    {
       // public OrderEntity addorder(orderModel od);
        public Task<OrderEntity> AddOrder(int bookid, int quantity, string token);
        public List<OrderEntity> GetAllOrders();
    }
}
