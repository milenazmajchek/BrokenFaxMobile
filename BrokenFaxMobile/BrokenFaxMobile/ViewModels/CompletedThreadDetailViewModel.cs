using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace BrokenFaxMobile.ViewModels
{
    [QueryProperty(nameof(CompletedThreadId), nameof(CompletedThreadId))]
    public class CompletedThreadDetailViewModel : BaseViewModel
    {
        private string itemId;
        private string term;
        private string creatorName;
        private string groupName;

        public string Id { get; set; }

        public string Term
        {
            get => term;
            set => SetProperty(ref term, value);
        }

        public string CreatorName
        {
            get => term;
            set => SetProperty(ref creatorName, value);
        }

        public string GroupName
        {
            get => groupName;
            set => SetProperty(ref groupName, value);
        }

        public string CompletedThreadId
        {
            get => itemId;
            set
            {
                itemId = value;
                LoadCompletedThread(value);
            }
        }

        public async void LoadCompletedThread(string itemId)
        {
            try
            {
                var item = await DataStoreCompleted.GetItemAsync(itemId);
                Id = item.Id;
                Term = item.Term;
                CreatorName = item.CreatorName;
                GroupName = item.GroupName;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

    }
}
