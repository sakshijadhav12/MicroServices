using BookStoreApplication_User.Context;
using BookStoreApplication_User.Entity;
using BookStoreApplication_User.Interface;
using BookStoreApplication_User.model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace BookStoreApplication_User.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser userService;
        private readonly BookStoreDBContext bookStoreDBContext;

        public UserController(IUser userService, BookStoreDBContext bookStoreDBContext)
        {
            this.userService = userService;
            this.bookStoreDBContext = bookStoreDBContext;   
        }

        [HttpPost]
        [Route("BookStoreApplication_register")]
        public IActionResult UserRegistration(Registration registration)
        {
            try
            {
                var result = userService.UserResgistrations(registration); 
                if (result != null)
                {
                    return Ok(new { Status = true, Message = "Registration successful", Data = result });
                }
                else
                {
                    return BadRequest(new { Status = false, Message = "Registration is not successful" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
       

        [HttpPost]
        [Route("login")]
        public IActionResult Login(string emailid, string password)
        {
            var result = userService.Login(emailid, password); 
            if (result != null)
            {
                return Ok(new { Status = true, Message = "Login successful", Data = result });
            }
            else
            {
                return BadRequest(new { Status = false, Message = "Login is not successful" });
            }
        }
        [Authorize]
        [HttpPost]
        [Route("getprofile")]
        public IActionResult getprofile()
        {
            int User_Id = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "User_Id").Value);
            var result = userService.getprofile(User_Id);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("not found");
            }
        }

        [Authorize]
        [HttpGet]
        [Route("MyProfile")]
        public ActionResult<UserEntity> MyProfile()
        {
            try
            {
                int User_Id = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "User_Id").Value);

                var user = bookStoreDBContext.User.FirstOrDefault(u => u.User_Id == User_Id);

                if (user != null)
                {
                    return Ok(user);
                }

                return NotFound("User not found");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
