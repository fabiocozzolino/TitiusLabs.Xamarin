using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
