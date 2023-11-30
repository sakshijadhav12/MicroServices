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
         public  BookStoreAdminEntity registeradmin(int Id, string name , string password)
        {
            try
            {

                BookStoreAdminEntity admin = new BookStoreAdminEntity();
                admin.AdminId = Id;
                admin.Password = password;
                admin.AdminName = name;
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
        public string admin_Login(int id,string password)
        {
            
            BookStoreAdminEntity verifyAdmin = adminDbContext.Admin.FirstOrDefault(x => x.AdminId == id && x.Password == password);
            if (verifyAdmin != null)
            {
                var token = GenerateToken(verifyAdmin.AdminId);
                return token;


            }
            else
            {
                return null;
            }
        }
        private string GenerateToken(int AdminId)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claimsIdentity = new ClaimsIdentity();
            claimsIdentity.AddClaim(new Claim("Id", AdminId.ToString()));
            var token = new JwtSecurityToken(configuration["Jwt:Issuer"],
                configuration["Jwt:Audience"],
                (System.Collections.Generic.IEnumerable<Claim>)claimsIdentity,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);

        }

    }
}
