using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using TitiusLabs.Forms.iOS.Controls;
using UIKit;
using FormSamples.Core;
using TitiusLabs.Forms.Controls;

namespace FormSamples.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init();

			LoadApplication(new App());
			return base.FinishedLaunching(app, options);
		}
	}
}
