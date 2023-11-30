using BookApplication.Order.cs.Entity;
using BookStoreApplicaion.Order.Entity; // Assuming this is the namespace where ResponseEntity is defined
using BookStoreApplication_User.Entity;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BookApplication.Order.cs.services
{
    public class APICallingcs
    {
        public async Task<BookEntity> GetBookById(int bookid)
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage responseObj = await client.GetAsync("https://localhost:44324/api/Books/viewBookById?BookId=" + bookid);

            if (responseObj.IsSuccessStatusCode)
            {
                string content = await responseObj.Content.ReadAsStringAsync();

              
                ResponseEntity<BookEntity> response = JsonConvert.DeserializeObject<ResponseEntity<BookEntity>>(content);
                return response.Data
                BookEntity book = JsonConvert.DeserializeObject<BookEntity>(response.Data.ToString());

                return book;
            }

            return null;
        }

        public async Task<UserEntity> GetUserProfileByIdAsync(int userId)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync("https://localhost:44324/api/User/MyProfile");

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

