using Microsoft.AspNetCore.Mvc;
using BookApplication.Order.cs.Context;
using System;
using BookApplication.Order.cs.Entity;
using BookApplication.Order.cs.Interface;
using System.Threading.Tasks;
using BookApplication.Order.cs.services;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System.Net;
using BookStoreApplicaion.Order.Entity;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Collections.Generic;

namespace BookApplication.Order.cs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrder orderservices;
        public OrderController(IOrder orderservices) 
        {
            this.orderservices = orderservices;
        }

        //[HttpGet]
        //[Route("GetUserDetails")]
        //public async Task<IActionResult> getuser()
        //{
        //    try
        //    {
        //        string token = Request.Headers["Authorization"];
        //        token = token.Substring("Bearer ".Length);
        //        var apiCallingService = new APICallingcs();
        //        var result = await apiCallingService.GetUserProfileById(token);
        //        if (result != null)
        //        {
                 
        //            return Ok(result);
        //        }
        //        else
        //        {
        //            return NotFound(); 
        //        }

        //    }
        //    catch(Exception ex) 
        //    {
        //        return null;

        //    }
        //}
        [HttpPost]
        [Route("AddOrder")]
        public async Task<IActionResult>  AddOrder(int BookId ,int Quntity)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                token = token.Substring("Bearer".Length);
                var result = await orderservices.AddOrder(BookId, Quntity, token);
                if (result != null)
                {

                    return Ok(new { status = true, message = " Book is Added", result });
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Status = false, Message = ex.Message });

            }

        }

        [HttpGet]
        [Route(" GetAllOrders")]
        public IActionResult GetAllOrders()
        {
            var result = this .orderservices.GetAllOrders();
            if(result != null)
            {
                return Ok(new { status = true, message = "orderget retrived", result });
            }
            else
            {
                return BadRequest("Not Found");
            }
        }

        
//        [HttpGet]
//        [Route("getboook")]
//        public async Task<IActionResult> Getbook(int bookid)
//        {
           
//            var result = await APICallingcs.GetBookById(bookid);
//;
//            if (result != null)
//            {
//                return Ok(result); 
//            }
//            else
//            {
//                return NotFound();
//            }
//        }


    }


}

            
    


        
               

