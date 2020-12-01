using BrokenFaxMobile.Services;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace BrokenFaxMobile.ViewModels
{
    [QueryProperty(nameof(ActiveThreadId), nameof(ActiveThreadId))]
    public class ProvideInputViewModel : BaseViewModel
    {
        private string activeThreadId;
        private bool isPicture;
        private bool isTerm;
        private string oldContent;
        private string from;

        public string ActiveThreadId
        {
            get
            {
                return activeThreadId;
            }
            set
            {
                activeThreadId = value;
                LoadActiveThreadId(value);
            }
        }

        public bool IsPicture
        {
            get => isPicture;
            set => SetProperty(ref isPicture, value);
        }
        public bool IsTerm
        {
            get => isTerm;
            set => SetProperty(ref isTerm, value);
        }

        public string OldContent
        {
            get => oldContent;
            set => SetProperty(ref oldContent, value);
        }

        public string From
        {
            get => from;
            set => SetProperty(ref from, value);
        }

        public async void LoadActiveThreadId(string id)
        {
            try
            {
                string token = "";
                /*var newUserInput = await WebApiHelper.GetLastThreadLinkAsync(token, id);*/
                var activeThread = await DataStore.GetItemAsync(id);
                isPicture = activeThread.Remaining % 2 == 0;
                isTerm = !isPicture;
                oldContent = activeThread.CreatorName;
                from = activeThread.GroupName;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Active thread");
            }
        }
    }
}
