using System;
using Android.App;
using Firebase.Iid;
using Android.Util;

namespace CometChatSample
{
	[Service]
    [IntentFilter(new[] { "com.google.firebase.INSTANCE_ID_EVENT" })]
    public class MyFirebaseIIDService : FirebaseInstanceIdService
    {
        const string TAG = "MyFirebaseIIDService Firebase";
        public override void OnTokenRefresh()
        {
            var refreshedToken = FirebaseInstanceId.Instance.Token;
			System.Console.WriteLine(TAG+ "Refreshed token: " + refreshedToken);
            SendRegistrationToServer(refreshedToken);
        }
        void SendRegistrationToServer(string token)
        {
			System.Console.WriteLine(TAG + "SendRegistrationToServer token: " + token);
            // Add custom implementation, as needed.
        }
    }
}
