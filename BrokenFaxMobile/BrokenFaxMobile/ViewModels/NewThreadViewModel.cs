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
        private bool missingGroup;
        private bool missingTerm;
        private bool missingImage;
           

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
            set
            {
                SetProperty(ref selectedGroup, value);
                if (value != null)
                    MissingGroup = false;
            }
        }

        public string NewTerm
        {
            get => newTerm;
            set
            {
                SetProperty(ref newTerm, value);
                if (!string.IsNullOrWhiteSpace(value))
                    MissingTerm = false;
            }
        }

        public bool MissingGroup
        {
            get => missingGroup;
            set => SetProperty(ref missingGroup, value);
        }

        public bool MissingTerm
        {
            get => missingTerm;
            set => SetProperty(ref missingTerm, value);
        }

        public bool MissingImage
        {
            get => missingImage;
            set => SetProperty(ref missingImage, value);
        }

        public async void InitializeGroupTypePicker()
        {
            Groups = await WebApiHelper.GetMembersGroupsAsync("token");
        }

    }
}
