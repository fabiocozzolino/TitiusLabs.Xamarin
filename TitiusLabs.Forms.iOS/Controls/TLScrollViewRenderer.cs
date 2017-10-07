using TitiusLabs.Forms.Controls;
using TitiusLabs.Forms.iOS.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

//[assembly: ExportRenderer(typeof(TLScrollView), typeof(TLScrollViewRenderer))]

namespace TitiusLabs.Forms.iOS.Controls
{
	public class TLScrollViewRenderer : ScrollViewRenderer
	{
		protected override void OnElementChanged(VisualElementChangedEventArgs e)
		{
			base.OnElementChanged(e);

			var element = e.NewElement as TLScrollView;
			element?.Render();
		}
	}
}
