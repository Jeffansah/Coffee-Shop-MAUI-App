namespace MAUIApp.Pages;
using Auth0.OidcClient;

public partial class OnboardingPage : ContentPage
{
    int count = 0;

    private readonly Auth0Client auth0Client;

    public OnboardingPage(Auth0Client client)

    {
        InitializeComponent();
        auth0Client = client;
    }

    private async void Signup_Clicked(object sender, EventArgs e)
    {
        var loginResult = await auth0Client.LoginAsync();

        if (!loginResult.IsError)
        {
            // Navigate to the home page upon successful login
            await Shell.Current.GoToAsync(nameof(SignUpPage));
        }
        else
        {
            // Handle login error if needed
            await DisplayAlert("Error", loginResult.ErrorDescription, "OK");
        }
    }


}
