using BookStoreApplication_User.Context;
using BookStoreApplication_User.Entity;
using BookStoreApplication_User.Interface;
using BookStoreApplication_User.model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;

namespace BookStoreApplication_User.service
{
    public class UserService : IUser
    {
        private readonly BookStoreDBContext bookStoreDBContext;
        private readonly IConfiguration configuration;

        public UserService(BookStoreDBContext bookStoreDBContext, IConfiguration configuration)
        {
            this.bookStoreDBContext = bookStoreDBContext;
            this.configuration = configuration;
        }
        public UserEntity UserResgistrations(Registration registration)
        {
            try
            {
                var existingUser = bookStoreDBContext.User.FirstOrDefault(u => u.EmailId == registration.EmailId);
                if (existingUser != null)
                {
                    throw new Exception("User with the same email address already exists.");

                }
                else
                {
                    UserEntity userentity = new UserEntity();
                    userentity.FirstName = registration.FirstName;
                    userentity.LastName = registration.LastName;
                    userentity.EmailId = registration.EmailId;
                    userentity.Password = registration.Password;
                    userentity.Address = registration.Address;
                    userentity.ContactNo = registration.ContactNo;
                    bookStoreDBContext.User.Add(userentity);
                    int result = bookStoreDBContext.SaveChanges();
                    if (result > 0)
                    {
                        return userentity;
                    }
                    else
                    {
                        return null;
                    }
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string Login(string emailid, string password)
        {

            UserEntity CheckIdAndPass = bookStoreDBContext.User.FirstOrDefault(x => x.EmailId == emailid && x.Password == password);
            if (CheckIdAndPass != null)
            {
                var token = GenerateToken(CheckIdAndPass.EmailId, CheckIdAndPass.User_Id);
                return token;


            }
            else
            {
                return null;
            }
        }

        public UserEntity getprofile (int User_Id)
        {
            try
            {
                UserEntity user = bookStoreDBContext.User.FirstOrDefault(x => x.User_Id == User_Id);
                if (user != null)
                {
                    return user;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex) 
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
