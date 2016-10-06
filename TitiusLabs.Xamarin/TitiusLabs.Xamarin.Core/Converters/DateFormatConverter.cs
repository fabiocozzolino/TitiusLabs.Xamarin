using System;
using Xamarin.Forms;
using System.Collections;
using System.Linq;
using System.Globalization;

namespace SpesaSicura
{

	public class DateFormatConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null) return "";

			DateTime d;
			if (DateTime.TryParse(value.ToString(), out d))
			{
				return d.ToString("dd/MM/yyyy");
			}

			return "";
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
