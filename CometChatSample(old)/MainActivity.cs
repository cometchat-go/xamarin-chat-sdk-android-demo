using Android.App;
using Android.Widget;
using Android.OS;
using Cometchat.Inscripts.Com.Cometchatcore.Coresdk;
using Org.Json;
using System;
using System.Runtime.Remoting.Contexts;
using Android.Views;
using Android.Text;

//Firebase Implementation
using Android.Gms.Common;
using Firebase.Messaging;
using Firebase.Iid;
using Android.Util;
using Firebase;
using Utils;
using Com.Inscripts.Orm;
using CometChatUIBinding.Additions;

namespace CometChatSample
{
    [Activity(Label = "CometChatSample", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity, Android.Views.View.IOnClickListener
    {
        int count = 1;
        CometChat cc = null;
        Context context = null;
        Activity activity = null;
        String siteurl = ""; 
        String licenseKey = "COMETCHAT-XXXXX-XXXXX-XXXXX-XXXXX"; // Replace the value with your CometChat License Key here
        String apiKey = "xxxxxxxxxxxxxxxxxxxxxx"; // Replace the value with your CometChat API Key here
        Boolean isCometOnDemand = true;
        private String UID1 = "SUPERHERO1";
        private String UID2 = "SUPERHERO2";
        private Button btnLoginSuperHero1, btnLoginSuperHero2, btnLaunchChat, btnInitializeChat;
        private ProgressBar pbLoading;
		const string TAG = "MainActivity";
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
			SugarContext.Init(this);
		
			//	System.Console.WriteLine(TAG+ "google app id: " + GetString(Resource.String.common_google_play_services_notification_channel_name));
            
			Firebase.FirebaseApp.InitializeApp(this);
            // Get our button from the layout resource,
            // and attach an event to it
            cc = CometChat.GetInstance(this.ApplicationContext);
            setUpFields();


      
        }
        private void setUpFields()
        {
            activity = this;
            btnLoginSuperHero1 = FindViewById<Button>(Resource.Id.btnLoginSuperHero1);
            btnLoginSuperHero2 = FindViewById<Button>(Resource.Id.btnLoginSuperHero2);
            btnLaunchChat = FindViewById<Button>(Resource.Id.btnLaunchChat);
            btnInitializeChat = FindViewById<Button>(Resource.Id.btnInitialize);

            pbLoading = FindViewById<ProgressBar>(Resource.Id.pb_loading);

            btnLoginSuperHero1.SetOnClickListener(this);
            btnLoginSuperHero2.SetOnClickListener(this);
            btnLaunchChat.SetOnClickListener(this);
            btnInitializeChat.SetOnClickListener(this);

        }

       





        public void OnClick(View v)
        {
            System.Console.WriteLine(" OnClick ");
			switch (v.Id)
			{
                case Resource.Id.btnInitialize:
                    initializeChat();
					break;
				case Resource.Id.btnLoginSuperHero1:
					login(UID1);
					break;
				case Resource.Id.btnLoginSuperHero2:
					login(UID2);
					break;
				case Resource.Id.btnLaunchChat:
					launchCometChat();
                    break;
            }
        }

        //Initialize CometChat
        private void initializeChat()
        {

            if (licenseKey != null && !TextUtils.IsEmpty(licenseKey))
            {

                if (apiKey != null && !TextUtils.IsEmpty(apiKey))
                {
                    showLoading(true);
                    cc.InitializeCometChat(siteurl, licenseKey, apiKey, isCometOnDemand, new CometChatCallback(success => successObject(success), fail => failObject(fail)));
                }
                else
                {
                    System.Console.WriteLine("Api Key Not Found ");
                    showLoading(false);
                }
            }
            else
            {
                System.Console.WriteLine("License Key Not Found  ");
                showLoading(false);
            }

        }

        private void failObject(JSONObject fail)
        {
            showLoading(false);
            System.Console.WriteLine("InitializeCometChat Fail " + fail.ToString());
        }

        private void successObject(JSONObject success)
        {
            System.Console.WriteLine("InitializeCometChat success " + success.ToString());
			showLoading(false);
			btnLoginSuperHero1.Enabled = true;
            btnLoginSuperHero2.Enabled = true;

        }

        //login CometChat
        private void login(String UID)
        {
            if (UID != null && !TextUtils.IsEmpty(UID))
            {
                showLoading(true);
                cc.LoginWithUID(this,UID, new CometChatCallback(success => loginSuccess(success), fail => loginFail(fail)));
            }

        }
		private void loginFail(JSONObject fail)
        {
			showLoading(false);
            System.Console.WriteLine("LoginWithUID Fail " + fail.ToString());
        }

        private void loginSuccess(JSONObject success)
        {
			showLoading(false);
            System.Console.WriteLine("LoginWithUID success " + success.ToString());
			btnLaunchChat.Enabled = true;
        }

        //LaunchCometChat

		private void launchCometChat()
        {
			cc.LaunchCometChat(activity, true, new LaunchCallbacks(successObj => successCall(successObj), fail => failCall(fail), onChatroomInfo => ChatroomInfo(onChatroomInfo), onError => Error(onError), onLogout => Logout(onLogout), onMessageReceive => MessageReceive(onMessageReceive), onUserInfo => UserInfo(onUserInfo), onWindowClose => WindowClose(onWindowClose)));
        }
		private void WindowClose(JSONObject onWindowClose)
        {
            System.Console.WriteLine("LaunchCometChat onWindowClose " + onWindowClose.ToString());
        }

        private void UserInfo(JSONObject onUserInfo)
        {
            System.Console.WriteLine("LaunchCometChat onUserInfo " + onUserInfo.ToString());
			String push_channel = onUserInfo.GetString("push_channel");
			System.Console.WriteLine("LaunchCometChat push_channel " + push_channel);
			FirebaseMessaging.Instance.SubscribeToTopic(push_channel);

        }

        private void MessageReceive(JSONObject onMessageReceive)
        {
            System.Console.WriteLine("LaunchCometChat onMessageReceive " + onMessageReceive.ToString());
        }

        private void Logout(JSONObject onLogout)
        {
            System.Console.WriteLine("LaunchCometChat onLogout" + onLogout.ToString());
        }

        private void Error(JSONObject onError)
        {
            System.Console.WriteLine("LaunchCometChat onError" + onError.ToString());
        }

        private void ChatroomInfo(JSONObject onChatroomInfo)
        {
            System.Console.WriteLine("LaunchCometChat onChatroomInfo" + onChatroomInfo.ToString());
        }

        private void failCall(JSONObject fail)
        {
            System.Console.WriteLine("LaunchCometChat " + fail.ToString());
        }

        private void successCall(JSONObject successObj)
        {
            System.Console.WriteLine("LaunchCometChat " + successObj.ToString());
        }

        //ProgressBar
        private void showLoading(Boolean show)
        {
            System.Console.WriteLine("showLoading");
            if (show)
            {
                pbLoading.Visibility = ViewStates.Visible;
                this.Window.AddFlags(WindowManagerFlags.Fullscreen | WindowManagerFlags.NotTouchable);
            }
            else
            {
                pbLoading.Visibility = ViewStates.Gone;
                this.Window.ClearFlags(WindowManagerFlags.Fullscreen | WindowManagerFlags.NotTouchable);
            }
        }
    }
}

