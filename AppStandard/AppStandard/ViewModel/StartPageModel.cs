using System;
using AppStandard.Interfaces;
using FreshMvvm;
using Plugin.Media;
using Plugin.MediaManager;
using Plugin.MediaManager.Abstractions;
using Plugin.MediaManager.Abstractions.Enums;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Xamarin.Forms;

namespace AppStandard
{
    public class StartPageModel : FreshBasePageModel
    {
        public Image SelectedImage
        {
            get;
            set;
        }


        private string VideoUrl = "https://pcbackend.pixelnet.de/files/9adeacc0-d34b-4eaf-adc6-53843cb65c12"; // "https://sec.ch9.ms/ch9/e68c/690eebb1-797a-40ef-a841-c63dded4e68c/Cognitive-Services-Emotion_high.mp4";

        //private string VideoUrl = "file:///var/mobile/Containers/Data/Application/EE861FD7-AC7B-4035-930A-410E714851A6/Documents/temp/0F308739-2948-4024-BEC6-D55463936641.MOV";

        private IDatabase databaseService;

        public Command PickFotoCommand
        {
            get
            { 
                return new Command(async () =>
                { 
                    await CrossMedia.Current.Initialize();

                    var photoLibraryStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Photos);

                    if (photoLibraryStatus != PermissionStatus.Granted)
                    {
                        var results = await CrossPermissions.Current.RequestPermissionsAsync(new[] { Permission.Photos });
                        photoLibraryStatus = results[Permission.Photos];
                    }  

                    if (photoLibraryStatus == PermissionStatus.Granted)
                    {

                        if (!CrossMedia.Current.IsPickPhotoSupported)
                        {
                            await CoreMethods.DisplayAlert("No Foto library", ":( No foto library available.", "OK");
                            return;
                        }

                        var file = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
                        {
                            CompressionQuality = 80,
                            PhotoSize = Plugin.Media.Abstractions.PhotoSize.Small
                        }); 

                        this.databaseService.UpdateDBValue("FotoFilePath", file.Path);
                        //await CoreMethods.DisplayAlert("File Location", file.Path, "OK");

                        this.SelectedImage.Source = ImageSource.FromStream(() =>
                        {
                            var stream = file.GetStream();
                            file.Dispose();
                            return stream;
                        });

                        var fotoFilePath = this.databaseService.ReadDBValue("FotoFilePath");
                    }
                    else
                    { 
                        await CoreMethods.DisplayAlert("Permissions Denied", "Unable to pick photos.", "OK");
                        //On iOS you may want to send your user to the settings screen.
                        //CrossPermissions.Current.OpenAppSettings();
                    }
                });
            }  
        }

        public Command TakeFotoCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await CrossMedia.Current.Initialize();

                    var cameraStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera);

                    if (cameraStatus != PermissionStatus.Granted)
                    {
                        var results = await CrossPermissions.Current.RequestPermissionsAsync(new[] { Permission.Camera });
                        cameraStatus = results[Permission.Camera];
                    }

                    if (cameraStatus == PermissionStatus.Granted)
                    {

                        if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                        {
                            await CoreMethods.DisplayAlert("No Camera available", ":( No camera available.", "OK");
                            return;
                        }

                        var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                        {
                            CompressionQuality = 80,
                            PhotoSize = Plugin.Media.Abstractions.PhotoSize.Small,
                            SaveToAlbum = true
                        });

                        this.databaseService.UpdateDBValue("FotoFilePath", file.Path);
                        //await CoreMethods.DisplayAlert("File Location", file.Path, "OK");
                         
                        this.SelectedImage.Source = ImageSource.FromStream(() =>
                        {
                            var stream = file.GetStream();
                            file.Dispose();
                            return stream;
                        });

                        var fotoFilePath = this.databaseService.ReadDBValue("FotoFilePath");
                    }
                    else
                    {
                        await CoreMethods.DisplayAlert("Permissions Denied", "Unable to take photos.", "OK");
                        //On iOS you may want to send your user to the settings screen.
                        //CrossPermissions.Current.OpenAppSettings();
                    }
                });
            }
        }

        public Command PickVideoCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await CrossMedia.Current.Initialize();

                    var photoLibraryStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Photos);

                    if (photoLibraryStatus != PermissionStatus.Granted)
                    {
                        var results = await CrossPermissions.Current.RequestPermissionsAsync(new[] { Permission.Photos });
                        photoLibraryStatus = results[Permission.Photos];
                    }

                    if (photoLibraryStatus == PermissionStatus.Granted)
                    {

                        if (!CrossMedia.Current.IsPickVideoSupported)
                        {
                            await CoreMethods.DisplayAlert("No Video library", ":( No video library available.", "OK");
                            return;
                        }
                         
                        var file = await CrossMedia.Current.PickVideoAsync();

                        this.databaseService.UpdateDBValue("VideoFilePath", file.Path);
                        //await CoreMethods.DisplayAlert("File Location", file.Path, "OK");

                        this.VideoUrl = "file://" + file.Path;
                        //this.VideoUrl = "http://www.endungen.de/AppVideo.MOV";  

                        var videoFilePath = this.databaseService.ReadDBValue("VideoFilePath");
                    }
                    else
                    {
                        await CoreMethods.DisplayAlert("Permissions Denied", "Unable to pick video.", "OK");
                        //On iOS you may want to send your user to the settings screen.
                        //CrossPermissions.Current.OpenAppSettings();
                    }
                });
            }
        }

        public Command TakeVideoCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await CrossMedia.Current.Initialize();

                    var cameraStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera);

                    if (cameraStatus != PermissionStatus.Granted)
                    {
                        var results = await CrossPermissions.Current.RequestPermissionsAsync(new[] { Permission.Camera });
                        cameraStatus = results[Permission.Camera];
                    }

                    if (cameraStatus == PermissionStatus.Granted)
                    {

                        if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakeVideoSupported)
                        {
                            await CoreMethods.DisplayAlert("No Camera available", ":( No camera available.", "OK");
                            return;
                        }

                        var file = await CrossMedia.Current.TakeVideoAsync(new Plugin.Media.Abstractions.StoreVideoOptions
                        {
                            Name = "SelfMadeVideo.mp4",
                            Directory = "SeldMadeVideos",
                            SaveToAlbum = true
                        });
                         
                        this.databaseService.UpdateDBValue("VideoFilePath", file.Path);
                        //await CoreMethods.DisplayAlert("File Location", file.Path, "OK");

                        this.VideoUrl = "file://" + file.Path;

                        var fotoFilePath = this.databaseService.ReadDBValue("VideoFilePath");
                    }
                    else
                    {
                        await CoreMethods.DisplayAlert("Permissions Denied", "Unable to take video.", "OK");
                        //On iOS you may want to send your user to the settings screen.
                        //CrossPermissions.Current.OpenAppSettings();
                    }
                });
            }
        }

        public Command PlayVideoCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await CrossMediaManager.Current.Play(this.VideoUrl, MediaFileType.Video);  
                });
            }
        }

        public Command StopVideoCommand
        {
            get
            {
                return new Command(async () =>
                {
                   await CrossMediaManager.Current.Stop();
                });
            }
        }


        public StartPageModel(IDatabase database)
        {
            this.databaseService = database;
            this.SelectedImage = new Image();
        }
    }
}
