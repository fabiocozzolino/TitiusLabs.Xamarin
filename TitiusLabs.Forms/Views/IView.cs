using TitiusLabs.Forms.ViewModels;

namespace TitiusLabs.Forms.Views
{
	public interface IView
	{
	}

	public interface IView<TViewModel> : IView where TViewModel : ViewModelBase
	{
		TViewModel ViewModel { get; set; }
	}
}
