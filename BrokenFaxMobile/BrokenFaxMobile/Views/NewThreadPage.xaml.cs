using BrokenFaxMobile.Services;
using BrokenFaxMobile.ViewModels;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BrokenFaxMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewThreadPage : ContentPage
    {
        private MediaFile mediaFile;
        private NewThreadViewModel viewmodel;
        private string url { get; set; }

        public NewThreadPage()
        {
            InitializeComponent();
            BindingContext = viewmodel = new NewThreadViewModel();
        }

        // Choose picture from device
        private async void btnSelectPic_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Error", "This is not supported on your device", "OK");
                return;
            }
            else
            {
                var mediaOption = new PickMediaOptions()
                {
                    PhotoSize = PhotoSize.Medium
                };

                mediaFile = await CrossMedia.Current.PickPhotoAsync();
                if (mediaFile == null)
                    return;

                imageView.Source = ImageSource.FromStream(() => mediaFile.GetStream());
            }
        }

        //Upload picture button    
        private async void btnUpload_Clicked(object sender, EventArgs e)
        {
            if (mediaFile == null)
            {
                await DisplayAlert("Error", "There was an error when trying to get your image.", "OK");
                return;
            }
            else
            {
                var imageUri = await UploadImage(mediaFile.GetStream());
                await WebApiHelper.StartFaxThreadAsync("token", viewmodel.SelectedGroup.Id, viewmodel.NewTerm, imageUri);
                imageView.Source = null;
                viewmodel.NewTerm = string.Empty;
                await DisplayAlert("Success!", "New thread is created!", "OK");
            }
        }

        //Take picture from camera    
        private async void btnTakePic_Clicked(object sender, EventArgs e)
        {

            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", ":(No Camera available.)", "OK");
                return;
            }
            else
            {
                mediaFile = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                {
                    Directory = "Sample",
                    Name = "myImage.jpg"
                });

                if (mediaFile == null) return;
                imageView.Source = ImageSource.FromStream(() => mediaFile.GetStream());
                var mediaOption = new PickMediaOptions()
                {
                    PhotoSize = PhotoSize.Medium
                };
            }
        }

        //Upload to blob function    
        private async Task<string> UploadImage(Stream stream)
        {
            Busy();
            /*
            var account = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=ahsanblobaccount;AccountKey=fOvpvzb8jFL0pNfDWvz9n76DzLWSlZu4aw6ZLXMbDId15YYfox15UoKvWMmTCJ6vcNoyk5w+A==;EndpointSuffix=core.windows.net");
            var client = account.CreateCloudBlobClient();
            var container = client.GetContainerReference("images");
            await container.CreateIfNotExistsAsync();
            var name = Guid.NewGuid().ToString();
            var blockBlob = container.GetBlockBlobReference($"{name}.png");
            await blockBlob.UploadFromStreamAsync(stream);
            url = blockBlob.Uri.OriginalString;
            UploadedUrl.Text = url;
            */
            var selectedGroup = viewmodel.SelectedGroup;
            var newTerm = viewmodel.NewTerm;
            NotBusy();
            return "url";
            //await DisplayAlert("Uploaded", "Image uploaded to Blob Storage Successfully!", "OK");
        }

        public void Busy()
        {
            uploadIndicator.IsVisible = true;
            uploadIndicator.IsRunning = true;
            btnSelectPic.IsEnabled = false;
            btnTakePic.IsEnabled = false;
            btnUpload.IsEnabled = false;
        }

        public void NotBusy()
        {
            uploadIndicator.IsVisible = false;
            uploadIndicator.IsRunning = false;
            btnSelectPic.IsEnabled = true;
            btnTakePic.IsEnabled = true;
            btnUpload.IsEnabled = true;
        }
    }
}