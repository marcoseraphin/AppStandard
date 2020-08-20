using System;
using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Runtime;
//using Plugin.FirebasePushNotification;
//using Plugin.FirebasePushNotification.Abstractions;
//using Android.Gms.Common;
//using Firebase.Messaging;
//using Firebase.Iid;
//using Android.Util;
//using Plugin.FirebasePushNotification;

namespace AppStandard.Droid
{
    [Application]
    public class MainApplication : Application
    {
        public MainApplication(IntPtr handle, JniHandleOwnership transer) : base(handle, transer)
        {
        }

                public override void OnCreate()
                {
                    base.OnCreate();

                    //Set the default notification channel for your app when running Android Oreo
        //            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
        //            {
        //                //Change for your default notification channel id here
        //                FirebasePushNotificationManager.DefaultNotificationChannelId = "FirebasePushNotificationChannel";

        //                //Change for your default notification channel name here
        //                FirebasePushNotificationManager.DefaultNotificationChannelName = "General";
        //            }


        //            //If debug you should reset the token each time.
        //#if DEBUG
        //            FirebasePushNotificationManager.Initialize(this, true);
        //#else
        //            FirebasePushNotificationManager.Initialize(this, false);
        //#endif


        //    //CrossFirebasePushNotification.Current.OnTokenRefresh += (s, p) =>
        //    //{
        //    //    System.Diagnostics.Debug.WriteLine($"TOKEN : {p.Token}");
        //    //};

        //    ////Handle notification when app is closed here
        //    //CrossFirebasePushNotification.Current.OnNotificationReceived += (s, p) =>
        //    //{
        //    //    System.Diagnostics.Debug.WriteLine("Received");
        //    //};

        //    //CrossFirebasePushNotification.Current.OnNotificationOpened += (s, p) =>
        //    //{
        //    //    System.Diagnostics.Debug.WriteLine("Opened");
        //    //    foreach (var data in p.Data)
        //    //    {
        //    //        System.Diagnostics.Debug.WriteLine($"{data.Key} : {data.Value}");
        //    //    }
        //    //};

        //    //CrossFirebasePushNotification.Current.OnNotificationAction += (s, p) =>
        //    //{
        //    //    System.Diagnostics.Debug.WriteLine("Action");

        //    //    if (!string.IsNullOrEmpty(p.Identifier))
        //    //    {
        //    //        System.Diagnostics.Debug.WriteLine($"ActionId: {p.Identifier}");
        //    //        foreach (var data in p.Data)
        //    //        {
        //    //            System.Diagnostics.Debug.WriteLine($"{data.Key} : {data.Value}");
        //    //        }
        //    //    }

        //    //};

        //    //CrossFirebasePushNotification.Current.OnNotificationDeleted += (s, p) =>
        //    //{

        //    //    System.Diagnostics.Debug.WriteLine("Deleted");

        //    //};


        }


    }
}
