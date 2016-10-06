using ViewModels;

namespace TitiusLabs.Xamarin.Core
{
	public interface IView
	{
	}

	public interface IView<TViewModel> : IView where TViewModel : ViewModelBase
	{
		TViewModel ViewModel { get; set; }
	}
}
