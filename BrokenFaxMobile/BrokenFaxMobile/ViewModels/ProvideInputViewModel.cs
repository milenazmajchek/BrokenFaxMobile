﻿using BrokenFaxMobile.Models;

using System;
using System.Diagnostics;
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
        private string fromText;

        // provided values
        private string providedTerm;

        public ProvideInputViewModel()
        {
            Title = "Provide Input";
            SubmitCommand = new Command(OnSubmitClicked);
        }

        public Command SubmitCommand { get; }

        public string ActiveThreadId
        {
            get => activeThreadId;
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

        public string ProvidedTerm
        {
            get => providedTerm;
            set => SetProperty(ref providedTerm, value);
        }

        public string FromText
        {
            get => fromText;
            set => SetProperty(ref fromText, value);
        }

        public async void LoadActiveThreadId(string id)
        {
            try
            {
                /*var newUserInput = await WebApiHelper.GetLastThreadLinkAsync(token, id);*/
                var activeThread = await DataStore.GetItemAsync(id);

                IsPicture = (activeThread.Length - activeThread.Remaining) % 2 == 0;
                IsTerm = !isPicture;
                var userInput = new NewUserInput();
                userInput.UserName = "Zika";
                if (IsPicture)
                    userInput.Content = "https://brokenfax.blob.core.windows.net/images/009bfac1-e723-483d-a879-18d398ccce28.jpg";
                else
                    userInput.Content = "Linija";

                OldContent = userInput.Content;
                From = userInput.UserName;
                FromText = $"From: {From}";
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Active thread");
            }
        }

        private async void OnSubmitClicked()
        {
            await Shell.Current.GoToAsync($"//main");
        }
    }
}
