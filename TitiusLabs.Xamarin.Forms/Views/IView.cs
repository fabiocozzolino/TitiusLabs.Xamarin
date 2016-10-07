using TitiusLabs.Xamarin.Forms.ViewModels;

namespace TitiusLabs.Xamarin.Forms.Views
{
	public interface IView
	{
	}

	public interface IView<TViewModel> : IView where TViewModel : ViewModelBase
	{
		TViewModel ViewModel { get; set; }
	}
}
