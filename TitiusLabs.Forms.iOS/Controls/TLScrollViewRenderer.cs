using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using TitiusLabs.Forms.Controls;
using TitiusLabs.Forms.iOS.Controls;

[assembly: ExportRenderer(typeof(TLScrollView), typeof(TLScrollViewRenderer))]

namespace TitiusLabs.Forms.iOS.Controls
{
	public class TLScrollViewRenderer : ScrollViewRenderer
	{
		private TLScrollView TLView
		{
			get
			{
				return this.Element as TLScrollView;
			}
		}

		protected override void OnElementChanged(VisualElementChangedEventArgs e)
		{
			base.OnElementChanged(e);

			this.TLView.PropertyChanged += TLScrollViewRenderer_PropertyChanged;
			ReloadSource();
		}

		void TLScrollViewRenderer_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "ItemsSource" || e.PropertyName == "ItemTemplate")
			{
				ReloadSource();
			}
		}

		void ReloadSource()
		{
			if (this.TLView.ItemTemplate == null || this.TLView.ItemsSource == null)
				return;

			var layout = new StackLayout();
			layout.Padding = 5;
			layout.Orientation = StackOrientation.Horizontal;

			foreach (var item in this.TLView.ItemsSource)
			{
				var viewCell = this.TLView.ItemTemplate.CreateContent() as ViewCell;
				viewCell.BindingContext = item;
				layout.Children.Add(viewCell.View);
			}

			this.TLView.Content = layout;
		}
	}
}
