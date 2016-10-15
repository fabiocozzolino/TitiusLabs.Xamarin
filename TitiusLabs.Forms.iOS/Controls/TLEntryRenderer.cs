using System;
using System.Linq;
using TitiusLabs.Core;
using TitiusLabs.Forms.Controls;
using TitiusLabs.Forms.iOS.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly:ExportRenderer(typeof(TLEntry), typeof(TLEntryRenderer))]

namespace TitiusLabs.Forms.iOS.Controls
{
	public class TLEntryRenderer : EntryRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);

			var element = e.NewElement as TLEntry;
			if (element.ReturnButton == ReturnButtonType.Next)
			{
				Control.ReturnKeyType = UIKit.UIReturnKeyType.Next;
				Control.ShouldReturn += (textField) =>
				{
					element.OnNext();
					return false;
				};
			}
		}
	}
}
