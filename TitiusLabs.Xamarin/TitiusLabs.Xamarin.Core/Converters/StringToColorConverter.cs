using System;
using Xamarin.Forms;

namespace SpesaSicura
{
	public class StringToColorConverter : IValueConverter
	{
		public StringToColorConverter ()
		{
		}

		#region IValueConverter implementation

		public object Convert (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			try {
				var converter = new ColorTypeConverter ();
				return (Color)converter.ConvertFromInvariantString (value.ToString().Trim());
			} catch (Exception) {
				return Colors.AlmostOrange;
			}
		}

		public object ConvertBack (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException ();
		}

		#endregion
	}
}

