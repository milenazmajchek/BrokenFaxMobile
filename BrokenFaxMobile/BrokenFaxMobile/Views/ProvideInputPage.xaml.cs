using BrokenFaxMobile.ViewModels;

using Plugin.Media;
using Plugin.Media.Abstractions;

using System;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BrokenFaxMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProvideInputPage : ContentPage
    {
        private MediaFile mediaFile;
        ProvideInputViewModel viewModel;

        public ProvideInputPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new ProvideInputViewModel();
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

                imageViewProvidePic.Source = ImageSource.FromStream(() => mediaFile.GetStream());
                viewModel.MissingImage = false;
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
                imageViewProvidePic.Source = ImageSource.FromStream(() => mediaFile.GetStream());
                var mediaOption = new PickMediaOptions()
                {
                    PhotoSize = PhotoSize.Medium
                };
                viewModel.MissingImage = false;
            }
        }
        
        //Submit    
        private async void btnUpload_Clicked(object sender, EventArgs e)
        {
            var canSubmit = true;
            if (viewModel.IsPicture && mediaFile == null)
            {
                canSubmit = false;
                viewModel.MissingImage = true;
            }

            if(viewModel.IsTerm && string.IsNullOrWhiteSpace(viewModel.ProvidedTerm))
            {
                canSubmit = false;
                viewModel.MissingTerm = true;
            }

            if (!canSubmit)
                return;

            await Shell.Current.GoToAsync($"//main");
        }

        //Upload to blob function    
        private async Task<string> UploadImage(Stream stream)
        {
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
            return "url";
            //await DisplayAlert("Uploaded", "Image uploaded to Blob Storage Successfully!", "OK");
        }
    }
}