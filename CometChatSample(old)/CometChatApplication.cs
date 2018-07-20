using System;
using Android.App;
using Android.Runtime;
using Com.Inscripts.Orm;

namespace CometChatSample
{
	[Application]
	public class CometChatApplication : Application
	{
        public CometChatApplication()
        {
        }

		public CometChatApplication(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
		{
		}
		public override void OnCreate()
        {
            base.OnCreate();
			SugarContext.Init(this);         
        }

		public override void OnTerminate()
		{
			base.OnTerminate();
			SugarContext.Terminate();
		}
	}
}
