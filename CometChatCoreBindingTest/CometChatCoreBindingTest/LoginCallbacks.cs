using System;
using Com.Inscripts.Interfaces;
using Org.Json;

namespace CometChatCoreBindingTest
{
	public class LoginCallbacks : Java.Lang.Object, ICallbacks
	{
		Action<Org.Json.JSONObject> _onSuccess;
		Action<Org.Json.JSONObject> _onFail;
		public LoginCallbacks(Action<Org.Json.JSONObject> onSuccess, Action<Org.Json.JSONObject> onFail)
		{
			this._onFail = onFail;
			this._onSuccess = onSuccess;
		}

		public void FailCallback(JSONObject p0)
		{
			this._onFail?.Invoke(p0);
		}

		public void SuccessCallback(JSONObject p0)
		{
			this._onSuccess?.Invoke(p0);
		}
	}

}
