using System;
using Com.Inscripts.Interfaces;
using Org.Json;

namespace CometChatCoreBindingTest
{

	public class LaunchCallbacks : Java.Lang.Object, ILaunchCallbacks
{
	Action<Org.Json.JSONObject> _onSuccess;
	Action<Org.Json.JSONObject> _onFail;
	Action<Org.Json.JSONObject> _onChatroomInfo;
	Action<Org.Json.JSONObject> _onError;
	Action<Org.Json.JSONObject> _onLogout;
	Action<Org.Json.JSONObject> _onMessageReceive;
	Action<Org.Json.JSONObject> _onUserInfo;
		Action<JSONObject> p1;
		Action<JSONObject> p2;

		public LaunchCallbacks(Action<Org.Json.JSONObject> onSuccess, Action<Org.Json.JSONObject> onFail, Action<Org.Json.JSONObject> onChatroomInfo, Action<Org.Json.JSONObject> onError, Action<Org.Json.JSONObject> onLogout, Action<Org.Json.JSONObject> onMessageReceive, Action<Org.Json.JSONObject> onUserInfo)
	{
        this._onFail = onFail;
       	this._onSuccess = onSuccess;
       	this._onChatroomInfo = onChatroomInfo;
       	this._onError = onError;
       	this._onLogout = onLogout;
       	this._onMessageReceive = onMessageReceive;
        this._onUserInfo = onUserInfo;
	}

	

		public void FailCallback(JSONObject p0)
	{
		this._onFail?.Invoke(p0);
	}

	public void SuccessCallback(JSONObject p0)
	{
		this._onSuccess?.Invoke(p0);
	}

	public void ChatroomInfoCallback(JSONObject p0)
	{
this._onChatroomInfo?.Invoke(p0);
	}

	public void Error(JSONObject p0)
	{
this._onError?.Invoke(p0);
	}


	public void OnLogout()
	{
	}

	public void OnMessageReceive(JSONObject p0)
	{
this._onMessageReceive?.Invoke(p0);
	}

	public void UserInfoCallback(JSONObject p0)
	{
this._onUserInfo?.Invoke(p0);
	}
	}
}
