using BookApplication.Order.cs.Entity;
using BookStoreApplicaion.Order.Entity;
using BookStoreApplication_User.Entity;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BookApplication.Order.cs.services
{
    public class APICallingcs
    {

        public static async Task<BookEntity> GetBookById(int bookid)
        {
            HttpClient client = new HttpClient();

            string url = "https://localhost:44324/api/Books/viewBookById?BookId=";

            HttpResponseMessage responseobj = await client.GetAsync(url + bookid);

            if (responseobj.IsSuccessStatusCode)
            {
                String Content = await responseobj.Content.ReadAsStringAsync();
                ResponseEntity<BookEntity> response = JsonConvert.DeserializeObject<ResponseEntity<BookEntity>>(Content);
                return response.Data;
                BookEntity book = JsonConvert.DeserializeObject<BookEntity>(response.Data.ToString());

                return book;
            }
            return null;
        }

        public async Task<UserEntity> GetUserProfileById(string token)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage response = await client.GetAsync("https://localhost:44323/api/User/MyProfile");
               

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    UserEntity user = JsonConvert.DeserializeObject<UserEntity>(content);

                    return user;
                }
                else
                {
                   
                    return null;
                }
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }
       
    }
}

