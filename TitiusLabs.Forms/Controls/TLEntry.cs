using System;
using Xamarin.Forms;

namespace TitiusLabs.Forms.Controls
{
	public class TLEntry : Xamarin.Forms.Entry
	{
		public static readonly BindableProperty ReturnButtonProperty = 
			BindableProperty.Create("ReturnButton", typeof(ReturnButtonType), typeof(TLEntry), ReturnButtonType.None);

		public ReturnButtonType ReturnButton
		{
			get { return (ReturnButtonType)GetValue(ReturnButtonProperty); }
			set { SetValue(ReturnButtonProperty, value); }
		}

		public static readonly BindableProperty NextViewProperty = 
			BindableProperty.Create("NextView", typeof(View), typeof(TLEntry));

		public View NextView
		{
			get { return (View)GetValue(NextViewProperty); }
			set { SetValue(NextViewProperty, value); }
		}

		public void OnNext()
		{
			NextView?.Focus();
		}
	}
}
