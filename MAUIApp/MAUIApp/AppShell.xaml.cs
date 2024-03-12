using MAUIApp.Pages;

namespace MAUIApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();


		RegisterRoutes();
	}

	

	//Registering routes
	private void RegisterRoutes()
	{

        Routing.RegisterRoute(nameof(SignInPage), typeof(SignInPage));
        Routing.RegisterRoute(nameof(SignUpPage), typeof(SignUpPage));
        Routing.RegisterRoute(nameof(MyOrdersPage), typeof(MyOrdersPage));
        Routing.RegisterRoute(nameof(OrdersDetails), typeof(OrdersDetails));
        Routing.RegisterRoute(nameof(DetailsPage), typeof(DetailsPage));
    }

	private async void Signout_MenuItem_Clicked(object sender, EventArgs e)
	{
		await Shell.Current.DisplayAlert("Alert", "Signed Out", "Ok");
	}
}

