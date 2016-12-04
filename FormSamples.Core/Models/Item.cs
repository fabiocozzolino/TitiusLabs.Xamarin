using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FormSamples.Core.Models
{

	public class Item : INotifyPropertyChanged
	{
		#region INotifyPropertyChanged implementation

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			var handler = PropertyChanged;
			if (handler != null)
				handler(this, new PropertyChangedEventArgs(propertyName));
		}

		#endregion

		private string _image;
		public string Image
		{
			get
			{
				return _image;
			}
			set
			{
				if (_image == value)
					return;

				_image = value;
				OnPropertyChanged();
			}
		}

		private string _name;
		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				if (_name == value)
					return;

				_name = value;
				OnPropertyChanged();
			}
		}
	}
}
