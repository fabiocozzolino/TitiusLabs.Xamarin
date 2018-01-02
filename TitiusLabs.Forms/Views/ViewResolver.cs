using System;
using System.Linq;
using System.Reflection;
using TitiusLabs.Forms.ViewModels;
using Xamarin.Forms;

namespace TitiusLabs.Forms.Views
{
    internal static class ViewResolver
    {
        public static Page GetViewFor<TargetViewModel>(TargetViewModel targetViewModel) where TargetViewModel : ViewModelBase, new()
        {
            var targetViewName = targetViewModel.GetType().Name.Replace("ViewModel", "Page");
            var definedTypes = targetViewModel.GetType().GetTypeInfo().Assembly.DefinedTypes;
            var targetType = definedTypes.FirstOrDefault(t => t.Name == targetViewName);
            return Activator.CreateInstance(targetType.AsType()) as Page;
        }
    }
}
