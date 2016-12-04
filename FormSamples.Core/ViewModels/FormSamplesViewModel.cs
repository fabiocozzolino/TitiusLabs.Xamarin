using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using FormSamples.Core.Models;
using TitiusLabs.Forms.Controls;
using TitiusLabs.Forms.ViewModels;
using Xamarin.Forms;

namespace FormSamples.Core.ViewModels
{

	public class FormSamplesViewModel : ViewModelBase
	{
		public bool IsVisible
		{
			get { return GetValue<bool>(); }
			set { SetValue(value); }
		}

		public Item SelectedItem
		{
			get { return GetValue<Item>(); }
			set { SetValue(value);}
		}

		public IEnumerable Items
		{
			get { return GetValue<IEnumerable>(); }
			set { SetValue(value); }
		}

		public FormSamplesViewModel()
		{
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

		public void ItemSelected_ExecuteCommand(object args)
		{
			SelectedItem = args as Item;
		}
	}
	
}
