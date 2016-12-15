using System.Diagnostics;
using Android.App;
using Android.Content;
using Android.Graphics;
using Microsoft.Azure.Mobile;
using Xamarin.Forms;

namespace keep.grass.Droid
{
	[Service]
	public class UpdateIntentService :IntentService
	{
		public override void OnCreate()
		{
			base.OnCreate();
			MobileCenter.Configure("0aaae641-48f0-4151-9bc5-def43896e5a9");
			global::Xamarin.Forms.Forms.Init(this, null);
		}

		protected override void OnHandleIntent(Intent intent)
		{
			Debug.WriteLine("UpdateIntentService::OnHandleIntent()");
			try
			{
				UpdateLastPublicActivity(intent);
			}
			finally
			{
				Android.Support.V4.Content.WakefulBroadcastReceiver.CompleteWakefulIntent(intent);
			}
		}

		void UpdateLastPublicActivity(Intent intent)
		{
			OmegaFactory.MakeSureInit();
			var Domain = AlphaFactory.MakeSureDomain() as OmegaDomain;
			try
			{
				Domain.ThreadContext.Value = this;
				Domain.BackgroundUpdateLastPublicActivityAsync().Wait();
			}
			finally
			{
				Domain.ThreadContext.Value = null;
			}
		}
	}
}

