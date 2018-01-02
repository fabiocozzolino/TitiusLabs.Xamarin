using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using TitiusLabs.Forms.ViewModels;
using Xamarin.Forms;

namespace TitiusLabs.Forms.Views
{
    public class PageBase<TViewModel> : ContentPage, IView<TViewModel> where TViewModel:ViewModelBase,new()
    {
        public TViewModel ViewModel
        {
            get
            {
                return GetValue(BindingContextProperty) as TViewModel;
            }
            set 
            {
                SetValue(BindingContextProperty, value);
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ViewModel.OnNavigationRequest = HandleNavigationRequest;
            ViewModel.OnModalNavigationRequest = HandleModalNavigationRequest;
            ViewModel.OnBackNavigationRequest = HandleBackNavigationRequest;
            ViewModel.OnCloseNavigationRequest = HandleCloseNavigationRequest;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            ViewModel.OnNavigationRequest = null;
            ViewModel.OnModalNavigationRequest = null;
            ViewModel.OnBackNavigationRequest = null;
            ViewModel.OnCloseNavigationRequest = null;
        }

        void HandleNavigationRequest(ViewModelBase targetViewModel)
        {
            var targetView = ViewResolver.GetViewFor(targetViewModel);
            Navigation.PushAsync(targetView).ConfigureAwait(true);
        }

        void HandleModalNavigationRequest(ViewModelBase targetViewModel)
        {
            var targetView = ViewResolver.GetViewFor(targetViewModel);
            Navigation.PushModalAsync(new NavigationPage(targetView)).ConfigureAwait(true);
        }

        void HandleBackNavigationRequest()
        {
            Navigation.PopAsync().ConfigureAwait(true);
        }

        void HandleCloseNavigationRequest()
        {
            Navigation.PopModalAsync(true).ConfigureAwait(true);
        }
    }
}
