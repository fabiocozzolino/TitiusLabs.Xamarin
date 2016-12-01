using System;

using Xamarin.Forms;
using System.Collections;
using System.Windows.Input;

namespace TitiusLabs.Forms.Controls
{
	public class TLScrollView : ScrollView
	{
		public static readonly BindableProperty ItemsSourceProperty =
			BindableProperty.Create("ItemsSource", typeof(IEnumerable), typeof(TLScrollView), default(IEnumerable));

		public IEnumerable ItemsSource
		{
			get { return (IEnumerable)GetValue(ItemsSourceProperty); }
			set { SetValue(ItemsSourceProperty, value); }
		}

		public static readonly BindableProperty ItemTemplateProperty =
			BindableProperty.Create("ItemTemplate", typeof(DataTemplate), typeof(TLScrollView), default(DataTemplate));

		public DataTemplate ItemTemplate
		{
			get { return (DataTemplate)GetValue(ItemTemplateProperty); }
			set { SetValue(ItemTemplateProperty, value); }
		}

		public event EventHandler<ItemTappedEventArgs> ItemTapped;


		public static readonly BindableProperty CommandProperty =
			BindableProperty.Create("Command", typeof(ICommand), typeof(TLScrollView), null);

		public ICommand Command
		{
			get { return (ICommand)GetValue(CommandProperty); }
			set { SetValue(CommandProperty, value); }
		}

		public static readonly BindableProperty CommandParameterProperty =
			BindableProperty.Create("CommandParameter", typeof(object), typeof(TLScrollView), null);

		public object CommandParameter
		{
			get { return GetValue(CommandParameterProperty); }
			set { SetValue(CommandParameterProperty, value); }
		}


		public TLScrollView()
		{
			this.PropertyChanged += TLScrollView_PropertyChanged;
		}

		void TLScrollView_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "ItemsSource" || e.PropertyName == "ItemTemplate")
			{
				ReloadSource();
			}
		}

		void ReloadSource()
		{
			if (this.ItemTemplate == null || this.ItemsSource == null)
				return;

			var layout = new StackLayout();
			layout.Orientation = this.Orientation == ScrollOrientation.Vertical ? StackOrientation.Vertical : StackOrientation.Horizontal;

			foreach (var item in this.ItemsSource)
			{
				var command = Command ?? new Command((obj) =>
				{
					var args = new ItemTappedEventArgs(ItemsSource, item);
					ItemTapped?.Invoke(this, args);
				});

				var viewCell = this.ItemTemplate.CreateContent() as ViewCell;
				viewCell.View.BindingContext = item;
				viewCell.View.GestureRecognizers.Add(new TapGestureRecognizer
				{
					Command = command,
					CommandParameter = CommandParameter,
					NumberOfTapsRequired = 1
				});

				layout.Children.Add(viewCell.View);
			}

			this.Content = layout;
		}
	}
}
