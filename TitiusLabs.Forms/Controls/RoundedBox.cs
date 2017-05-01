using System;
using Xamarin.Forms;

namespace TitiusLabs.Forms.Controls
{
	public class RoundedBox : ContentView
	{
		public static readonly BindableProperty CornerRadiusProperty =
			BindableProperty.Create(nameof(CornerRadius), typeof(double), typeof(RoundedBox), 0.0);

		public double CornerRadius
		{
			get { return (double)GetValue(CornerRadiusProperty); }
			set { SetValue(CornerRadiusProperty, value); }
		}

		public static readonly BindableProperty BorderWidthProperty =
			BindableProperty.Create(nameof(BorderWidth), typeof(double), typeof(RoundedBox), 0.0);

		public double BorderWidth
		{
			get { return (double)GetValue(BorderWidthProperty); }
			set { SetValue(BorderWidthProperty, value); }
		}

		public static readonly BindableProperty BorderColorProperty =
			BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(RoundedBox), Color.Transparent);

		public Color BorderColor
		{
			get { return (Color)GetValue(BorderColorProperty); }
			set { SetValue(BorderColorProperty, value); }
		}
	}
}
