using BookStoreAppliacation.Admin.Entity;
using BookStoreAppliacation.Admin.Interface;
using BookStoreAppliacation.Admin.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Threading.Tasks;

namespace BookStoreAppliacation.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdmin adminService;
        private readonly Apicalling apicalling;

        public AdminController(IAdmin adminService, Apicalling apicalling)
        {
            this.adminService = adminService;
            this.apicalling = apicalling;
        }

        [HttpPost]
        [Route("registeradmin")]
        public IActionResult RegisterAdmin(AdminModel adminModel)
        {
            try
            {
                var result = adminService.registeradmin(adminModel);
                if (result != null)
                {
                    return Ok(new { Status = true, Message = "Admin registered successfully", Data = result });
                }
                else
                {
                    return BadRequest(new { Status = false, Message = "Registration failed" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("login_Admin")]
        public IActionResult AdminLogin(string EmailId, string password)
        {
            try
            {
                var token = adminService.admin_Login(EmailId, password);
                if (token != null)
                {
                    return Ok(new { Status = true, Message = "Login successful", Data = token });
                }
                else
                {
                    return BadRequest(new { Status = false, Message = "Login failed" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet]
        [Route("getusers")]
        public async Task<IActionResult> getUser()
        {
            try
            {
                var result = await apicalling.getUsers();
                if(result!=null)
                {
                    return Ok(new { status = true, message = " Users are Retrived", data = result });
                    
                 }
                else
                {
                    return BadRequest(new { status = true , message = "users are nit retrived"  }); 
                }
            }
            catch(Exception ex)
            {
                return null;
            }

            
              
        }

        [HttpGet]
        [Route("GetBookOutOFStock")]
        public async Task<IActionResult> getBookAsync()
        {
            try
            {
                var result = await apicalling.GetBooks();
                if (result != null)
                {
                    return Ok(new { status = true, message = " Book is Retrived", data = result });
                }
                else
                {
                    return BadRequest(new { Status = false, mesage = " book is not retrived " });
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }



    }

