using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TitiusLabs.Forms.Controls;
using TitiusLabs.Forms.ViewModels;
using Xamarin.Forms;

namespace FormSamples.Core
{
	public partial class FormSamplesPage : ContentPage
	{
		TLEntry Entry1 = new TLEntry();
		TLEntry Entry2 = new TLEntry();
		TLEntry Entry3 = new TLEntry();

		public FormSamplesPage()
		{
			InitializeComponent();

			this.BindingContext = new MyViewModel();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			Entry1.NextView = Entry2;
			Entry1.ReturnButton = ReturnButtonType.Next;

			Entry2.NextView = Entry3;
			Entry2.ReturnButton = ReturnButtonType.Next;

			Entry3.NextView = Entry1;
			Entry3.ReturnButton = ReturnButtonType.Next;

			this.Body.Children.Add(Entry1);
			this.Body.Children.Add(Entry2);
			this.Body.Children.Add(Entry3);
		}

		void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
		{
			DisplayAlert("Item Selezionato", (e.Item as Item).Name, "cancel");
		}
	}

	public class MyViewModel : ViewModelBase
	{
		public bool IsVisible
		{
			get { return GetValue<bool>(); }
			set { SetValue(value); }
		}

		public IEnumerable Items
		{
			get { return GetValue<IEnumerable>(); }
			set { SetValue(value); }
		}

		public MyViewModel()
		{
			var t = new TLScrollView();
			
			this.IsVisible = false;
			this.Items = new Item[] {
				new Item{Image = "http://www.clubparadiso.it/upload/CONF66/20150909/Green_Island_Resort_Barriera_corallina-tSa-80X80.jpg", Name="Barriera Corallina" },
				new Item{Image = "http://www.clubparadiso.it/upload/CONF66/20150515/Vahine_Island_Resort-tSa-80X80.jpg", Name="Barriera Corallina 1"},
				new Item{Image = "http://neckeropen.com/wp-content/uploads/2015/04/necker-island-810x320-80x80.jpg", Name="Barriera Corallina 2"},
				new Item{Image = "http://media.apkseeker.com/apps/personalization/76119/w80-76119.jpg", Name="Barriera Corallina 3"},
				new Item{Image = "http://4everstatic.com/immagini/80x80/natura/barriera-corallina,-pesci-colorati-148311.jpg", Name="Barriera Corallina 4"},
				new Item{Image = "http://www.clubparadiso.it/upload/CONF66/20150729/Yasawa_Islands_Resort_e_SPA_giardino-tSa-80X80.jpg", Name="Barriera Corallina 5"},
				new Item{Image = "http://thailandluxe.net/wp-content/uploads/2015/06/Bamboo-Island1-e1434357108153-80x80.jpg", Name="Barriera Corallina 6"},
				new Item{Image = "http://www.amando.it/imagesdyn/gallery_plus/80x80/12/80/la-grande-barriera-corallina-dellaustralia_128073.jpg", Name="Barriera Corallina 7"},
				new Item{Image = "http://tartapedia.it/wp-content/themes/arthemia-premium/scripts/timthumb.php?src=/http://tartapedia.it/wp-content/uploads/2013/06/PROTEGGIAMO-LA-BARRIERA-CORALLINA.jpg&w=80&h=80&zc=1&q=100", Name="Barriera Corallina 7"},
				new Item{Image = "http://www.amando.it/imagesdyn/gallery_plus/80x80/12/80/belize-blue-hole_128072.jpg", Name="Barriera Corallina 7"}
			};
		}
	}

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
