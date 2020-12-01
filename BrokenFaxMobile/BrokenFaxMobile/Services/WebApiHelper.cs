using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using BrokenFaxMobile.Models;
using System.Threading.Tasks;

namespace BrokenFaxMobile.Services
{
    public static class WebApiHelper
    {
        // 
        public static async Task<NewUserInput> GetLastThreadLinkAsync(string token, string faxThreadId)
        {
            /*
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync("");
            var newuser = JsonConvert.DeserializeObject<NewUserInput>(response);*/
            
            //TODO: remove this part
            var newuser = new NewUserInput();
            newuser.UserName = "Zika";
            newuser.UserId = 12345;
            newuser.Content = "This is the end";

            return newuser;
        }
    }
}
