using BookApplication.Order.cs.Entity;

namespace BookApplication.Order.cs.Interface
{
    public interface IOrder
    {
        public OrderEntity addorder(orderModel od);
    }
}
