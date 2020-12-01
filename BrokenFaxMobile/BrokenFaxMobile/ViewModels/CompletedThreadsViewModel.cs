﻿using BrokenFaxMobile.Models;
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
    public class CompletedThreadsViewModel : BaseViewModel
    {
        private CompleteThreadData _selectedItem;

        public ObservableCollection<CompleteThreadData> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command<CompleteThreadData> ItemTapped { get; }

        public CompletedThreadsViewModel()
        {
            Title = "Completed Threads";
            Items = new ObservableCollection<CompleteThreadData>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<CompleteThreadData>(OnItemSelected);
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStoreCompleted.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
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

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public CompleteThreadData SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        async void OnItemSelected(CompleteThreadData item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(CompletedThreadDetailPage)}?{nameof(CompletedThreadDetailViewModel.CompletedThreadId)}={item.Id}");
        }
    }
}
