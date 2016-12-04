using FormSamples.Core.Models;
using FormSamples.Core.ViewModels;
using Xamarin.Forms;

namespace FormSamples.Core.Views
{
	public partial class FormSamplesPage : ContentPage
	{
		//TLEntry Entry1 = new TLEntry();
		//TLEntry Entry2 = new TLEntry();
		//TLEntry Entry3 = new TLEntry();

		public FormSamplesPage()
		{
			InitializeComponent();

			this.BindingContext = new FormSamplesViewModel();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			//Entry1.NextView = Entry2;
			//Entry1.ReturnButton = ReturnButtonType.Next;

			//Entry2.NextView = Entry3;
			//Entry2.ReturnButton = ReturnButtonType.Next;

			//Entry3.NextView = Entry1;
			//Entry3.ReturnButton = ReturnButtonType.Next;

			//this.Body.Children.Add(Entry1);
			//this.Body.Children.Add(Entry2);
			//this.Body.Children.Add(Entry3);
		}

		void Handle_ItemSelected(object sender, Xamarin.Forms.ItemTappedEventArgs e)
		{
			DisplayAlert("Item Selezionato", (e.Item as Item).Name, "cancel");
		}
	}




}
