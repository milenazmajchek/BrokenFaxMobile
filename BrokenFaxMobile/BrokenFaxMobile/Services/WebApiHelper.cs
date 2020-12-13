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
        #region ThreadHandling 
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

        public static async Task<string> StartFaxThreadAsync(string token, int groupId, string term, string imageUri)
        {
            //returns new thread ID
            return "1";
        }
        #endregion

        #region GroupHandling
        public static async Task<List<GroupMembership>> GetGroupMembershipsAsync(string token)
        {
            /*
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync("");
            var newuser = JsonConvert.DeserializeObject<NewUserInput>(response);*/

            //TODO: remove this part
            return new List<GroupMembership>() {
                new GroupMembership { GroupId = 1, GroupName="Group1", IsMember=true },
                new GroupMembership { GroupId = 2, GroupName="Group2", IsMember=false }
                };
        }

        public static async Task AddGroupMembershipAsync(string token, int groupId)
        {
        }

        public static async Task RemoveGroupMembershipAsync(string token, int groupId)
        {
        }

        public static async Task AddGroupAsync(string token, string NewGroupName)
        {
        }

        public static async Task<List<GroupData>> GetMembersGroupsAsync(string token)
        {
            return new List<GroupData>()
            {
                new GroupData {Id=1, Name="Group1"},
                new GroupData {Id=1, Name="Group2"}
            };

        }
        #endregion
    }
}
