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

        async Task HandleNavigationRequest(ViewModelBase targetViewModel)
        {
            var targetView = ViewResolver.GetViewFor(targetViewModel);
            targetView.BindingContext = targetViewModel;
            await Navigation.PushAsync(targetView);
        }

        async Task HandleModalNavigationRequest(ViewModelBase targetViewModel)
        {
            var targetView = ViewResolver.GetViewFor(targetViewModel);
            targetView.BindingContext = targetViewModel;
            await Navigation.PushModalAsync(new NavigationPage(targetView));
        }

        async Task HandleBackNavigationRequest()
        {
            await Navigation.PopAsync();
        }

        async Task HandleCloseNavigationRequest()
        {
            await Navigation.PopModalAsync(true);
        }
    }
}
