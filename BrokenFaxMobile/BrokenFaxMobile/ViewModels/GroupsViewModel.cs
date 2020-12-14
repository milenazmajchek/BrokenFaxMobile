using BrokenFaxMobile.Models;
using BrokenFaxMobile.Services;

using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BrokenFaxMobile.ViewModels
{
    public class GroupsViewModel : BaseViewModel
    {
        private string newGroupName;

        public GroupsViewModel()
        {
            Title = "Groups";
            Groups = new ObservableCollection<GroupsViewData>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            CreateGroupCommand = new Command(async () => await OnCreateGroup());
        }

        public ObservableCollection<GroupsViewData> Groups { get; }

        public Command LoadItemsCommand { get; }

        public Command AddItemCommand { get; }

        public Command CreateGroupCommand { get; }

        public Command<GroupsViewData> ChangeMembershipCmd
        {
            get => new Command<GroupsViewData>((data) => OnChangeMembership(data));
        }

        public string NewGroupName
        {
            get => newGroupName;
            set => SetProperty(ref newGroupName, value);
        }

        public void OnAppearing()
        {
            IsBusy = true;
        }

        private async void OnChangeMembership(GroupsViewData data)
        {
            if (data.IsMember)
                await WebApiHelper.RemoveGroupMembershipAsync("temp", data.GroupId);
            else
                await WebApiHelper.AddGroupMembershipAsync("temp", data.GroupId);
        }

        private async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Groups.Clear();
                var items = await WebApiHelper.GetGroupMembershipsAsync("test");
                foreach (var item in items)
                {
                    Groups.Add(new GroupsViewData(item));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task OnCreateGroup()
        {
            if (string.IsNullOrWhiteSpace(NewGroupName))
                return;

            await WebApiHelper.AddGroupAsync("token", NewGroupName);
        }
    }

    public class GroupsViewData : GroupMembership
    {
        public string CommandText { get; }
        public GroupsViewData(GroupMembership origin)
        {
            GroupId = origin.GroupId;
            GroupName = origin.GroupName;
            IsMember = origin.IsMember;
            CommandText = origin.IsMember ? "Leave" : "Join";
        }
    }
}
