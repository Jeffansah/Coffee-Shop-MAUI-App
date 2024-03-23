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

        Routing.RegisterRoute(nameof(CartPage), typeof(CartPage));
        Routing.RegisterRoute(nameof(CheckoutPage), typeof(CheckoutPage));
    }

}

