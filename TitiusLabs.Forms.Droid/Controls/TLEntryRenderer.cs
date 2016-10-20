using System;
using TitiusLabs.Forms.Controls;
using TitiusLabs.Forms.Droid.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(TLEntry), typeof(TLEntryRenderer))]

namespace TitiusLabs.Forms.Droid.Controls
{
	public class TLEntryRenderer : EntryRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);

			var element = e.NewElement as TLEntry;
			if (element.ReturnButton == ReturnButtonType.Next)
			{
				Control.ImeOptions = Android.Views.InputMethods.ImeAction.Next;
				Control.EditorAction += (sender, args) =>
				{
					element.OnNext();
				};
			}
		}
	}
}
