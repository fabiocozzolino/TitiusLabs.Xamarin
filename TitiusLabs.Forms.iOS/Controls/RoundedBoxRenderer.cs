using System;
using TitiusLabs.Forms.Controls;
using TitiusLabs.Forms.iOS.Controls;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(RoundedBox), typeof(RoundedBoxRenderer))]

namespace TitiusLabs.Forms.iOS.Controls
{
	public class RoundedBoxRenderer : ViewRenderer<RoundedBox, UIView>
	{
		protected override void OnElementChanged(ElementChangedEventArgs<RoundedBox> e)
		{
			base.OnElementChanged(e);

			if (Element == null)
				return;

			var nativeControl = Platform.GetRenderer(Element.Content) as UIView;
			AddSubview(nativeControl);
		}

		public override void Draw(CoreGraphics.CGRect rect)
		{
			base.Draw(rect);

			Layer.MasksToBounds = true;
			Layer.CornerRadius = (float)this.Element.CornerRadius / (float)UIScreen.MainScreen.Scale;
			Layer.BorderColor = this.Element.BorderColor.ToCGColor();
			Layer.BorderWidth = (float)this.Element.BorderWidth;
		}
	}
}
