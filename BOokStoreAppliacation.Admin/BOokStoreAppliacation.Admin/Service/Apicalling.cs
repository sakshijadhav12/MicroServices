using BookStoreAppliacation.Admin.Entity;
using BookStoreAppliacation.Admin.Interface;
using BookStoreApplicaion.Books.Entity.QueryEntity;
using BookStoreApplication_User.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net.Http;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace BookStoreAppliacation.Admin.Service
{
    public class Apicalling
    {
        public async Task<List<BookEntity>> GetBooks()
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync("https://localhost:44324/api/Books/OutOFStockBook");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    List<BookEntity> books = JsonConvert.DeserializeObject<List<BookEntity>>(content);
                    return books;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        
        public async Task <List<UserEntity>> getUsers()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://localhost:44323/api/User/getallusers");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                List<UserEntity> users = JsonConvert.DeserializeObject<List<UserEntity>>(content);
                return users;

            }
            else
            {
                return null;
            }

        }
    }



}

