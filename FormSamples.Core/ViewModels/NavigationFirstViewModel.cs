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

        public string Title { get { return GetValue<string>(); } set { SetValue(value); } }

        public NavigationFirstViewModel()
        {
            GoToSecondPageCommand = new Command(async () => await NavigateTo(new NavigationSecondViewModel(){ Title = "Second View Title"}));
            CancelCommand = new Command(async () => await Close());
        }
    }
}
