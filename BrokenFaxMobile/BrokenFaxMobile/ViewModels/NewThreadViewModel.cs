using BrokenFaxMobile.Models;
using BrokenFaxMobile.Services;

using System.Collections.Generic;

namespace BrokenFaxMobile.ViewModels
{
    public class NewThreadViewModel : BaseViewModel
    {
        private List<GroupData> groups;
        private GroupData selectedGroup;
        private string newTerm;

        public NewThreadViewModel()
        {
            InitializeGroupTypePicker();
        }

        public List<GroupData> Groups
        {
            get => groups;
            set => SetProperty(ref groups, value);
        }

        public GroupData SelectedGroup
        {
            get => selectedGroup;
            set => SetProperty(ref selectedGroup, value);
        }

        public string NewTerm
        {
            get => newTerm;
            set => SetProperty(ref newTerm, value);
        }

        public async void InitializeGroupTypePicker()
        {
            Groups = await WebApiHelper.GetMembersGroupsAsync("token");
        }

    }
}
