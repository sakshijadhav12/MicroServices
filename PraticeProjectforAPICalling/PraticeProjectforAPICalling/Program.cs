using Newtonsoft.Json;
using PraticeProjectforAPICalling;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PraticeProjectforAPICalling
{
    internal class Program
    {
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("Hello World!");
        //}

        static async Task Main(string[] srgs)
        {
            APICalling aPICalling = new APICalling();
            int pageNo = 2;
            List<User> users = await aPICalling.GetUsers(pageNo);
            if (users != null)
            {
                Console.WriteLine($"Users on page {pageNo}:");
                foreach (var user in users)
                {
                    Console.WriteLine($"Id: {user.id},email: {user.email}, firstName: {user.first_name},lasttName: {user.last_name}");
                }
            }
            else
            {
                Console.WriteLine("Failed to retrieve users. Check the API response.");
            }

            //creteUser
            CreateRequestModel newUser = new CreateRequestModel
            {
                Name= "sakshi",
                Job = "Devloper",
               
            };

            CreateResponseModel createResponse = await aPICalling.CreateUser(newUser);

            if (createResponse != null)
            {
                Console.WriteLine($"User created successfully  {createResponse.id} ,{createResponse.Name},{createResponse.Job}");
            }
            else
            {
                Console.WriteLine("Failed to create user.");
            }
        }
    }
}

        

   
      


