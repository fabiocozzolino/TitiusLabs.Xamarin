using System;
using Xamarin.Forms;
using System.Collections;
using System.Linq;

namespace SpesaSicura
{
	public class NoVisibilityConverter : IValueConverter
	{
		public NoVisibilityConverter ()
		{
		}

		#region IValueConverter implementation

		public object Convert (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			var visibilityConverter = new VisibilityConverter ();
			return !(bool)visibilityConverter.Convert (value, targetType, parameter, culture);
		}

		public object ConvertBack (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return null;
		}

		#endregion
	}

}

