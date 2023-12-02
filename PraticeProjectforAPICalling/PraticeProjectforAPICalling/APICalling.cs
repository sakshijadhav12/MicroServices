using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PraticeProjectforAPICalling
{
    public class APICalling
    {
        public async Task<List<User>> GetUsers(int pageNo)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://reqres.in/api/users?page=" + pageNo);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                APIResponse apiResponse = JsonConvert.DeserializeObject<APIResponse>(content);
                if (apiResponse != null)
                {
                    return apiResponse.Data;
                }
                else
                {
                    return null;
                }


            }
            else
            {
                return null;
            }

        }



        public async Task<CreateResponseModel> CreateUser(CreateRequestModel requestData)
        {
            using (HttpClient client = new HttpClient())
            {
                string jsonRequestData = JsonConvert.SerializeObject(requestData);
                HttpContent content = new StringContent(jsonRequestData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("https://reqres.in/api/users", content);
                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    CreateResponseModel profile = JsonConvert.DeserializeObject<CreateResponseModel>(responseContent);
                    return profile;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
