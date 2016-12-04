using Xamarin.Forms;
using FormSamples.Core.Views;

namespace FormSamples.Core
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			MainPage = new FormSamplesPage();
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
