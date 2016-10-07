using System;
using Xamarin.Forms;
using System.Collections;
using System.Linq;

namespace TitiusLabs.Xamarin.Core.Converters
{
	public class VisibilityConverter : IValueConverter
	{
		public VisibilityConverter ()
		{
		}

		#region IValueConverter implementation

		public object Convert (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (value is bool)
			{
				return ((bool)value);
			}
			if (value is string)
			{
				int i;
				if (int.TryParse((string)value, out i))
				{
					return i > 0;
				}
				return (!string.IsNullOrEmpty((string)value));
			}
			if (value is IEnumerable)
			{
				var list = value as IEnumerable;
				return list.Cast<object>().Any();
			}
			if (value == null)
			{
				return false;
			}

			return true;
		}

		public object ConvertBack (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return null;
		}

		#endregion
	}

}

