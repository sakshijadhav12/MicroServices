using BookApplication.Order.cs.Context;
using BookApplication.Order.cs.Entity;
using BookApplication.Order.cs.Interface;
using BookApplication.Order.cs.Migrations;
using BookStoreApplicaion.Order.Entity;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

namespace BookApplication.Order.cs.services
{
    public class Orderservices : IOrder
    {
        private readonly OrderDbContext orderDBContext;
        private readonly IConfiguration configuration;

        public Orderservices(OrderDbContext orderDBContext, IConfiguration configuration)
        {
            this.orderDBContext = orderDBContext;
            this.configuration = configuration;
        }

        /// <summary>
        /// Adds the order.
        /// </summary>
        /// <param name="bookid">The bookid.</param>
        /// <param name="quantity">The quantity.</param>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">Error occurred during order addition.</exception>
        public async Task<OrderEntity> AddOrder(int bookid, int quantity, string token)
        {
            try
            {
                OrderEntity order = new OrderEntity
                {
                    BookId = bookid,
                    Quntity = quantity,

                };
                APICallingcs apiCalling = new APICallingcs();
                order.BookDetails = await APICallingcs.GetBookById(bookid);
                order.UserDetails = await apiCalling.GetUserProfileById(token);
                order.OrderAmount = quantity * order.BookDetails.OriginalPrice;
                orderDBContext.Orders.Add(order);
                var result = orderDBContext.SaveChanges();
                if (result != null)
                {
                    return order;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred during order addition.", ex);
            }
        }
      

        public List<OrderEntity> GetAllOrders()
        {
            try
            {
                List<OrderEntity> orders = orderDBContext.Orders.ToList();
                if (orders != null)
                {
                    return orders;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while retrieving all orders.", ex);
            }
        }

        
        
    }
}