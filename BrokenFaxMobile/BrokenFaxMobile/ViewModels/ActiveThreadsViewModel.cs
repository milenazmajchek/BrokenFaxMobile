using BrokenFaxMobile.Models;
using BrokenFaxMobile.Services;
using BrokenFaxMobile.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BrokenFaxMobile.ViewModels
{
    public class ActiveThreadsViewModel : BaseViewModel
    {
        public ObservableCollection<ActiveFaxThreadViewData> ActiveThreads { get; }
        public Command LoadItemsCommand { get; }
        public Command<ActiveFaxThreadViewData> ProvideInputCmd 
        {
            get => new Command<ActiveFaxThreadViewData>((data) => OnProvideInputCmd(data));
        }

        public ActiveThreadsViewModel()
        {
            Title = "Active Threads";
            ActiveThreads = new ObservableCollection<ActiveFaxThreadViewData>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        public void OnAppearing()
        {
            IsBusy = true;
        }

        private async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                ActiveThreads.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    ActiveThreads.Add(new ActiveFaxThreadViewData(item));
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

        private async void OnProvideInputCmd(ActiveFaxThreadViewData data)
        {
            await Shell.Current.GoToAsync($"{nameof(ProvideInputPage)}?{nameof(ProvideInputViewModel.ActiveThreadId)}={data.Id}");
        }
    }

    public class ActiveFaxThreadViewData : ActiveFaxThreadData
    {
        public string NextText { get; }
        public bool IsUserNext { get; }
        public ActiveFaxThreadViewData(ActiveFaxThreadData origin)
        {
            Id = origin.Id;
            CreatorName = origin.CreatorName;
            NextText = (origin.Length - origin.Remaining) % 2 == 0 ? "Pic" : "Text";
            IsUserNext = origin.NextId == MockDataStoreActiveThreads.CurrentUserId;
            GroupName = origin.GroupName;
            NextName = origin.NextName;
            Remaining = origin.Remaining;
        }
    }
}
