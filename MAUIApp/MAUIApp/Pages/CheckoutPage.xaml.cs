namespace MAUIApp.Pages;

public partial class CheckoutPage : ContentPage
{
	public CheckoutPage()
	{
		InitializeComponent();
	}

    private async void GoHome_Clicked(System.Object sender, System.EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
    }
}

