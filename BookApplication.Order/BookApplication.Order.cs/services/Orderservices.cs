using BookApplication.Order.cs.Context;
using BookApplication.Order.cs.Entity;
using BookApplication.Order.cs.Interface;
using BookStoreApplicaion.Order.Entity;
using Microsoft.Extensions.Configuration;
using System;

namespace BookApplication.Order.cs.services
{
    public class Orderservices:IOrder
    {
        private readonly OrderDbContext orderDBContext;
        private readonly IConfiguration configuration;

        public Orderservices(OrderDbContext orderDBContext, IConfiguration configuration)
        {
            this.orderDBContext = orderDBContext;
            this.configuration = configuration;
        }

        public OrderEntity addorder(orderModel od)
        {
            try
            {   
                OrderEntity orderEntity = new OrderEntity();
                orderEntity.BookId = od.BookId;
                orderEntity.UserId = od.UserId;
                orderEntity.Quntity = od.Quntity;
                orderEntity.orderDate = od.orderDate;
                orderDBContext.Orders.Add(orderEntity);
                int result = orderDBContext.SaveChanges();
                if (result > 0)
                {
                    return orderEntity;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
