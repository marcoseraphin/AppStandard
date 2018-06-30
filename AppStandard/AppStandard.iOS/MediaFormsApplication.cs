using System;
using Foundation;
using Plugin.MediaManager;
using UIKit;

namespace AppStandard.iOS
{
    [Register(Application.AppName)]
    public class MediaFormsApplication : UIApplication
    {
        private MediaManagerImplementation MediaManager => (MediaManagerImplementation)CrossMediaManager.Current;

        public override void RemoteControlReceived(UIEvent uiEvent)
        {
            MediaManager.MediaRemoteControl.RemoteControlReceived(uiEvent);
        }

    }
}
