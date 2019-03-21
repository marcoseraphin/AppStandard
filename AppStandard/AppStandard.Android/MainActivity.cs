
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Plugin.Permissions;
using Acr.UserDialogs;

namespace AppStandard.Droid
{
    [Activity(Label = "AppStandard", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        static readonly string TAG = "MainActivity";

        internal static readonly string CHANNEL_ID = "my_notification_channel";
        internal static readonly int NOTIFICATION_ID = 100;

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            Plugin.CurrentActivity.CrossCurrentActivity.Current.Activity = this;
            UserDialogs.Init(this);

            base.OnCreate(bundle);

//            Set the default notification channel for your app when running Android Oreo
//            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
//                {
//                    Change for your default notification channel id here
    
//                    FirebasePushNotificationManager.DefaultNotificationChannelId = "FirebasePushNotificationChannel";

//                    Change for your default notification channel name here
    
//                    FirebasePushNotificationManager.DefaultNotificationChannelName = "General";
//            }


//            If debug you should reset the token each time.
//#if DEBUG
//            FirebasePushNotificationManager.Initialize(this, true);
//#else
//              FirebasePushNotificationManager.Initialize(this,false);
//#endif


//            CrossFirebasePushNotification.Current.OnTokenRefresh += (s, p) =>
//            {
//                System.Diagnostics.Debug.WriteLine($"TOKEN : {p.Token}");
//            };

//            Handle notification when app is closed here
//            CrossFirebasePushNotification.Current.OnNotificationReceived += (s, p) =>
//            {
//                System.Diagnostics.Debug.WriteLine("Received");
//            };

//            CrossFirebasePushNotification.Current.OnNotificationOpened += (s, p) =>
//            {
//                System.Diagnostics.Debug.WriteLine("Opened");
//                foreach (var data in p.Data)
//                {
//                    System.Diagnostics.Debug.WriteLine($"{data.Key} : {data.Value}");
//                }


//            };

//            CrossFirebasePushNotification.Current.OnNotificationAction += (s, p) =>
//            {
//                System.Diagnostics.Debug.WriteLine("Action");

//                if (!string.IsNullOrEmpty(p.Identifier))
//                {
//                    System.Diagnostics.Debug.WriteLine($"ActionId: {p.Identifier}");
//                    foreach (var data in p.Data)
//                    {
//                        System.Diagnostics.Debug.WriteLine($"{data.Key} : {data.Value}");
//                    }

//                }

//            };

//            CrossFirebasePushNotification.Current.OnNotificationDeleted += (s, p) =>
//            {

//                System.Diagnostics.Debug.WriteLine("Deleted");

//            };

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }

		public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
		{
			base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
		}

        /// <summary>
        /// IsPlayServicesAvailable
        /// </summary>
        /// <returns></returns>
        //public bool IsPlayServicesAvailable()
        //{
        //    string infoMessage = string.Empty;
        //    int resultCode = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(this);
        //    if (resultCode != ConnectionResult.Success)
        //    {
        //        if (GoogleApiAvailability.Instance.IsUserResolvableError(resultCode))
        //            infoMessage = GoogleApiAvailability.Instance.GetErrorString(resultCode);
        //        else
        //        {
        //            infoMessage = "This device is not supported";
        //            Finish();
        //        }
        //        return false;
        //    }
        //    else
        //    {
        //        infoMessage = "Google Play Services is available.";
        //        return true;
        //    }
        //}

        /// <summary>
        /// CreateNotificationChannel
        /// </summary>
        //private void CreateNotificationChannel()
        //{
        //    if (Build.VERSION.SdkInt < BuildVersionCodes.O)
        //    {
        //         Notification channels are new in API 26 (and not a part of the
        //         support library). There is no need to create a notification
        //         channel on older versions of Android.
        //        return;
        //    }

        //    var channel = new NotificationChannel(CHANNEL_ID,
        //                                          "FCM Notifications",
        //                                          NotificationImportance.Default)
        //    {

        //        Description = "Firebase Cloud Messages appear in this channel"
        //    };

        //    var notificationManager = (NotificationManager)GetSystemService(Android.Content.Context.NotificationService);
        //    notificationManager.CreateNotificationChannel(channel);
        //}
    }


}

