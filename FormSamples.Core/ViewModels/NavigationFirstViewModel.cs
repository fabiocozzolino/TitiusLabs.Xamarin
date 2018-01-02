using System;
using System.Windows.Input;
using TitiusLabs.Forms.ViewModels;
using Xamarin.Forms;

namespace FormSamples.Core.ViewModels
{
    public class NavigationFirstViewModel : ViewModelBase
    {
        public ICommand GoToSecondPageCommand
        {
            get{ return GetValue<ICommand>();}
            set { SetValue(value); }
        }

        public ICommand CancelCommand
        {
            get { return GetValue<ICommand>(); }
            set { SetValue(value); }
        }

        public NavigationFirstViewModel()
        {
            GoToSecondPageCommand = new Command(() => NavigateTo(new NavigationSecondViewModel()));
            CancelCommand = new Command(() => Close());
        }
    }
}
