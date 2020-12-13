using BrokenFaxMobile.Models;
using BrokenFaxMobile.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BrokenFaxMobile.ViewModels
{
    public class NewThreadViewModel : BaseViewModel
    {
        private List<GroupData> groups;
        private GroupData selectedGroup;
        private string newTerm;
        public List<GroupData> Groups
        {
            get => groups;
            set
            {
                SetProperty(ref groups, value);
            }
        }

        // Account Type
        public GroupData SelectedGroup
        {
            get { return selectedGroup; }
            set
            {
                SetProperty(ref selectedGroup, value);
            }
        }

        public string NewTerm
        {
            get => newTerm;
            set
            {
                SetProperty(ref newTerm, value);
            }
        }

        public NewThreadViewModel()
        {
            InitializeGroupTypePicker();
        }

        public async void InitializeGroupTypePicker()
        {
            //Device.BeginInvokeOnMainThread(() => IsLoading = true);

            Groups = await WebApiHelper.GetMembersGroupsAsync("token");
            //Device.BeginInvokeOnMainThread(() => IsLoading = false);
        }

    }
}
