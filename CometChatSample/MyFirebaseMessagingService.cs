using System;
using Android.App;
using Android.Content;
using Android.Media;
using Android.Util;
using Firebase.Messaging;
using Utils;

namespace CometChatSample
{
	[Service]
    [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
    public class MyFirebaseMessagingService : FirebaseMessagingService
    {
        const string TAG = "MyFirebaseMsgService Firebase";
        public override void OnMessageReceived(RemoteMessage message)
        {
			CCNotificationHelper.ProcessCCNotificationData(this,message,Resource.Drawable.cometchat_logo,Resource.Drawable.cometchat_logo);
        }
    }
}
