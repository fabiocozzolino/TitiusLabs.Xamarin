using System;
using System.Windows.Input;
using TitiusLabs.Forms.ViewModels;
using Xamarin.Forms;

namespace FormSamples.Core.ViewModels
{
    public class NavigationSecondViewModel : ViewModelBase
    {
        public ICommand GoBackCommand
        {
            get { return GetValue<ICommand>(); }
            set { SetValue(value); }
        }

        public ICommand CancelCommand
        {
            get { return GetValue<ICommand>(); }
            set { SetValue(value); }
        }

        public NavigationSecondViewModel()
        {
            GoBackCommand = new Command(() => NavigateBack());
            CancelCommand = new Command(() => Close());
        }
    }
}
