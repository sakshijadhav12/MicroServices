using BookStoreAppliacation.Admin.Entity;
using BookStoreAppliacation.Admin.Interface;
using BookStoreAppliacation.Admin.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreAppliacation.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdmin adminService;

        public AdminController(IAdmin adminService)
        {
            this.adminService = adminService;
        }

        [HttpPost]
        [Route("registeradmin")]
        public IActionResult RegisterAdmin(BookStoreAdminEntity admin)
        {
            try
            {
                var result = adminService.registeradmin(admin.AdminId, admin.AdminName, admin.Password);
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
        public IActionResult AdminLogin(int id, string password)
        {
            try
            {
                var token = adminService.admin_Login(id, password);
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
    }
}
