using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using FormSamples.Core.Models;
using Models;
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

		public ObservableCollection<Item> Items
		{
			get { return GetValue<ObservableCollection<Item>>(); }
			set { SetValue(value); }
		}

        public ICommand MyCommand
        {
            get;
            set;
		}

		public ICommand AddRandomImageCommand
		{
			get;
			set;
		}

		public ICommand RemoveRandomImageCommand
		{
			get;
			set;
		}

		public ICommand ResetListCommand
		{
			get;
			set;
		}

		public ICommand ClearListCommand
		{
			get;
			set;
		}

		public FormSamplesViewModel()
		{
			this.IsVisible = false;
            Initialize();

            MyCommand = new Command(() =>
            {
            });

            AddRandomImageCommand = new Command(() =>
			{
				if (Items == null)
					Initialize();
                var index = new Random().Next(0, Items.Count > 0 ? Items.Count - 1 : 0);
				this.Items.Insert(index, new Item { Image = "https://previews.123rf.com/images/milla74/milla741103/milla74110300213/9192536-Panoramic-view-of-Polignano-a-Mare-Apulia--Stock-Photo-puglia.jpg", Name = "Polignano" });
			});

			RemoveRandomImageCommand = new Command(() =>
			{
                if (Items == null)
                    Initialize();
				var index = new Random().Next(0, Items.Count > 0 ? Items.Count - 1 : 0);
				this.Items.RemoveAt(index);
			});

			ResetListCommand = new Command(() =>
			{
				this.Initialize();
			});

			ClearListCommand = new Command(() =>
			{
				this.Items = null;
			});
		}

        void Initialize()
        {
			this.Items = new ObservableCollection<Item> {
				new Item{Image = "http://www.clubparadiso.it/upload/CONF66/20150909/Green_Island_Resort_Barriera_corallina-tSa-80X80.jpg", Name="Barriera Corallina" },
				new Item{Image = "http://www.clubparadiso.it/upload/CONF66/20150515/Vahine_Island_Resort-tSa-80X80.jpg", Name="Il Paradiso"},
				new Item{Image = "http://4everstatic.com/immagini/80x80/natura/barriera-corallina,-pesci-colorati-148311.jpg", Name="We Are In Puglia"},
				new Item{Image = "http://www.clubparadiso.it/upload/CONF66/20150729/Yasawa_Islands_Resort_e_SPA_giardino-tSa-80X80.jpg", Name="Maldive"},
				new Item{Image = "http://www.amando.it/imagesdyn/gallery_plus/80x80/12/80/la-grande-barriera-corallina-dellaustralia_128073.jpg", Name="La Grande Barriera Corallina"},
				new Item{Image = "http://tartapedia.it/wp-content/themes/arthemia-premium/scripts/timthumb.php?src=/http://tartapedia.it/wp-content/uploads/2013/06/PROTEGGIAMO-LA-BARRIERA-CORALLINA.jpg&w=80&h=80&zc=1&q=100", Name="Proteggiamo la natura"},
				new Item{Image = "http://www.amando.it/imagesdyn/gallery_plus/80x80/12/80/belize-blue-hole_128072.jpg", Name="Azzurro, azzurro"}
			};
        }

		public void ItemSelected_ExecuteCommand(object args)
		{
			SelectedItem = args as Item;
		}

		public void Speak_ExecuteCommand(object args)
		{
			var text = args.ToString();
			DependencyService.Get<ITextToSpeech>().Speak(text);
		}
	}
}
