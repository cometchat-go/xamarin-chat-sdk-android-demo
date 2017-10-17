package md5103d0d6829a36c2bd9f254d6ed2727d8;


public class LaunchCallbacks
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.inscripts.interfaces.LaunchCallbacks
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_chatroomInfoCallback:(Lorg/json/JSONObject;)V:GetChatroomInfoCallback_Lorg_json_JSONObject_Handler:Com.Inscripts.Interfaces.ILaunchCallbacksInvoker, cometchatbindingapp\n" +
			"n_error:(Lorg/json/JSONObject;)V:GetError_Lorg_json_JSONObject_Handler:Com.Inscripts.Interfaces.ILaunchCallbacksInvoker, cometchatbindingapp\n" +
			"n_failCallback:(Lorg/json/JSONObject;)V:GetFailCallback_Lorg_json_JSONObject_Handler:Com.Inscripts.Interfaces.ILaunchCallbacksInvoker, cometchatbindingapp\n" +
			"n_onLogout:()V:GetOnLogoutHandler:Com.Inscripts.Interfaces.ILaunchCallbacksInvoker, cometchatbindingapp\n" +
			"n_onMessageReceive:(Lorg/json/JSONObject;)V:GetOnMessageReceive_Lorg_json_JSONObject_Handler:Com.Inscripts.Interfaces.ILaunchCallbacksInvoker, cometchatbindingapp\n" +
			"n_successCallback:(Lorg/json/JSONObject;)V:GetSuccessCallback_Lorg_json_JSONObject_Handler:Com.Inscripts.Interfaces.ILaunchCallbacksInvoker, cometchatbindingapp\n" +
			"n_userInfoCallback:(Lorg/json/JSONObject;)V:GetUserInfoCallback_Lorg_json_JSONObject_Handler:Com.Inscripts.Interfaces.ILaunchCallbacksInvoker, cometchatbindingapp\n" +
			"";
		mono.android.Runtime.register ("CometChatCoreBindingTest.LaunchCallbacks, CometChatCoreBindingTest, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", LaunchCallbacks.class, __md_methods);
	}


	public LaunchCallbacks () throws java.lang.Throwable
	{
		super ();
		if (getClass () == LaunchCallbacks.class)
			mono.android.TypeManager.Activate ("CometChatCoreBindingTest.LaunchCallbacks, CometChatCoreBindingTest, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void chatroomInfoCallback (org.json.JSONObject p0)
	{
		n_chatroomInfoCallback (p0);
	}

	private native void n_chatroomInfoCallback (org.json.JSONObject p0);


	public void error (org.json.JSONObject p0)
	{
		n_error (p0);
	}

	private native void n_error (org.json.JSONObject p0);


	public void failCallback (org.json.JSONObject p0)
	{
		n_failCallback (p0);
	}

	private native void n_failCallback (org.json.JSONObject p0);


	public void onLogout ()
	{
		n_onLogout ();
	}

	private native void n_onLogout ();


	public void onMessageReceive (org.json.JSONObject p0)
	{
		n_onMessageReceive (p0);
	}

	private native void n_onMessageReceive (org.json.JSONObject p0);


	public void successCallback (org.json.JSONObject p0)
	{
		n_successCallback (p0);
	}

	private native void n_successCallback (org.json.JSONObject p0);


	public void userInfoCallback (org.json.JSONObject p0)
	{
		n_userInfoCallback (p0);
	}

	private native void n_userInfoCallback (org.json.JSONObject p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
