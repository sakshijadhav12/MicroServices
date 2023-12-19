using BookStoreAppliacation.Admin.Dbcontext;
using BookStoreAppliacation.Admin.Entity;
using BookStoreAppliacation.Admin.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Xml.Linq;

namespace BookStoreAppliacation.Admin.Service
{
    public class AdminService : IAdmin
    { 
         private readonly AdminDbContext adminDbContext;
        private readonly IConfiguration configuration;

        public AdminService(AdminDbContext adminDbContext, IConfiguration configuration) 
        {  
            this.adminDbContext = adminDbContext;
            this.configuration = configuration;
        }
         public  BookStoreAdminEntity registeradmin(AdminModel adminModel)
        {
            try
            {

                BookStoreAdminEntity admin = new BookStoreAdminEntity();
                admin.AdminName = adminModel.Name;
                admin.EmailId = adminModel.EmailId;
                admin.Password = adminModel.Password;
               
                adminDbContext.Admin.Add(admin);
                int result = adminDbContext.SaveChanges();
                if (result > 0)
                {
                    return admin;
                }
                else
                {
                    return null;
                }

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public string admin_Login(string EmailId,string password)
        {
            
            BookStoreAdminEntity verifyAdmin = adminDbContext.Admin.FirstOrDefault(x => x.EmailId== EmailId  && x.Password == password);
            if (verifyAdmin != null)
            {
                var token = GenerateToken(verifyAdmin.EmailId,verifyAdmin.AdminId);
                return token;


            }
            else
            {
                return null;
            }
        }

  
        private string GenerateToken(string EmailId, int User_Id)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim("Email", EmailId),
                  new Claim(ClaimTypes.Role,"Admin"),

                        new Claim("User_Id", User_Id.ToString())
            };
            var token = new JwtSecurityToken(configuration["Jwt:Issuer"],
                configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);

        }

    }
}
