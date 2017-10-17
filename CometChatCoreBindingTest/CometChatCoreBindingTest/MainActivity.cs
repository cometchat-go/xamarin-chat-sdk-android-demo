using Android.App;
using Android.Widget;
using Android.OS;
using Cometchat.Inscripts.Com.Cometchatcore.Coresdk;
using Cometchat.Inscripts.Com.Readyui;
using Com.Inscripts.Interfaces;
using Org.Json;
using Android.Support.V7.App;

namespace CometChatCoreBindingTest
{
	[Activity(Label = "CometChat", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : AppCompatActivity
	{
		int count = 1;
		CometChat cc = null;
		Activity aa = null;
		Button button;
		EditText siteurl, username, password;
		CheckBox isFullScreen;
		public Activity Context { get; private set; }
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);


			SetContentView(Resource.Layout.Main);
			aa = this;
			cc = CometChat.GetInstance(this.ApplicationContext);



			// Get our button from the layout resource,
			// and attach an event to it
			 button = FindViewById<Button>(Resource.Id.myButton);
			 siteurl = FindViewById<EditText>(Resource.Id.siteURL);
			 username = FindViewById<EditText>(Resource.Id.Username);
			 password = FindViewById<EditText>(Resource.Id.Password);
			isFullScreen= FindViewById<CheckBox>(Resource.Id.fullscreen);

			username.Text = "USERNAME";
			password.Text = "PASSWORD";
			siteurl.Text = "SITEURL";



			button.Click += delegate
			{

				cc.InitializeCometChat("SITEURL", "LICENSE-KEY", "API-KEY", false, new LoginCallbacks(success => successObject(success), fail => failObject(fail)));


			};

		}


		public void successObject(JSONObject p0)
		{
			System.Console.WriteLine("Login success ");
			if (aa != null)
			{
				Toast.MakeText(this.ApplicationContext, "success", ToastLength.Short).Show();
				cc.Login(username.Text, password.Text, new LoginCallbacks(success => successObj(success), fail => failObj(fail)));
			}      
		}

		public void failObject(JSONObject p0)
		{
			System.Console.WriteLine("fail " + p0);
		}



		public void successObj(JSONObject p0)
		{
			System.Console.WriteLine("Login success ");
			if (aa != null)
			{
				Toast.MakeText(this.ApplicationContext, "success", ToastLength.Short).Show();
				bool popup = isFullScreen.Checked ? true : false;
				cc.LaunchCometChat(aa, popup, new LaunchCallbacks(successObj => success(successObj), fail => failObj(fail), onChatroomInfo => ChatroomInfo(onChatroomInfo), onError => Error(onError), onLogout => Logout(onLogout), onMessageReceive => MessageReceive(onMessageReceive), onUserInfo => UserInfo(onUserInfo)));

			}
		}

		public void failObj(JSONObject p0)
		{

		}


		public void success(JSONObject p0)
		{
		}

		public void fail(JSONObject p0)
		{
		}

		public void ChatroomInfo(JSONObject p0)
		{
		}

		public void Error(JSONObject p0)
		{
		}
		public void Logout(JSONObject p0)
		{
		}

		public void MessageReceive(JSONObject p0)
		{
		}

		public void UserInfo(JSONObject p0)
		{
		}
	}
}

