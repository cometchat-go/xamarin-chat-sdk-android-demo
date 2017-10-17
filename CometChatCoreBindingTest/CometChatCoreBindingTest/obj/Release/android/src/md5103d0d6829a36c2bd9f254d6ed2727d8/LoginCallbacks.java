package md5103d0d6829a36c2bd9f254d6ed2727d8;


public class LoginCallbacks
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.inscripts.interfaces.Callbacks
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_failCallback:(Lorg/json/JSONObject;)V:GetFailCallback_Lorg_json_JSONObject_Handler:Com.Inscripts.Interfaces.ICallbacksInvoker, cometchatbindingapp\n" +
			"n_successCallback:(Lorg/json/JSONObject;)V:GetSuccessCallback_Lorg_json_JSONObject_Handler:Com.Inscripts.Interfaces.ICallbacksInvoker, cometchatbindingapp\n" +
			"";
		mono.android.Runtime.register ("CometChatCoreBindingTest.LoginCallbacks, CometChatCoreBindingTest, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", LoginCallbacks.class, __md_methods);
	}


	public LoginCallbacks () throws java.lang.Throwable
	{
		super ();
		if (getClass () == LoginCallbacks.class)
			mono.android.TypeManager.Activate ("CometChatCoreBindingTest.LoginCallbacks, CometChatCoreBindingTest, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void failCallback (org.json.JSONObject p0)
	{
		n_failCallback (p0);
	}

	private native void n_failCallback (org.json.JSONObject p0);


	public void successCallback (org.json.JSONObject p0)
	{
		n_successCallback (p0);
	}

	private native void n_successCallback (org.json.JSONObject p0);

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
