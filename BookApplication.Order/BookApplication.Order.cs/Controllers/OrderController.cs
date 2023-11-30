using Microsoft.AspNetCore.Mvc;
using BookApplication.Order.cs.Context;
using System;
using BookApplication.Order.cs.Entity;
using BookApplication.Order.cs.Interface;

namespace BookApplication.Order.cs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrder orderservices;
        OrderController(IOrder orderservices) 
        {
            this.orderservices = orderservices;
        }

        [HttpPost]
        [Route("AddOrder")]
        public IActionResult Addorer( orderModel orderModel)
        {
            try
            {
                var result = orderservices.addorder(orderModel);
                if(result != null) 
                {
                     return Ok(new { Status = true, Message = "order is  added successfully", Data = result });
                }
                else
                {
                    return BadRequest(new { Status = false, Message = "Failed to add the book" });
                }

            }
            catch(Exception ex) 
            {
                return StatusCode(500, new { Status = false, Message = ex.Message });
            }
        }

            
    }
}

        
               

