using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BrokenFaxMobile.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        private string howToPlayText = "Broken Fax game is an on-line version of the game of Telephone Pictionary. \r\n \r\n  Game threads are created in a group level, where any member of the group can create a thread at any time, and any number of threads can be active at the same time. \r\n\r\n Threads are created on the New Thread page, where you need to come up with a term and a drawing that depicts the term. \r\n\r\n Each thread will have a random order of group members who will need to either describe the drawing of the previous member, or draw the previous description. \r\n\r\n You will see all active threads of the groups you're a member of in the Active Threads page, and be prompted to provide input for threads in which it's your turn. \r\n\r\n Once a thread is completed you'll be able to see everyone's contribution to the thread in the Completed Threads page.";

        public string HowToPlayText
        {
            get => howToPlayText;
        }

        public AboutViewModel()
        {
            Title = "Info";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("http://brokenfax.azurewebsites.net/Info"));
        }

        public ICommand OpenWebCommand { get; }
    }
}