namespace MAUIApp.Pages;

public partial class OnboardingPage : ContentPage
{
	public OnboardingPage()
	{
		InitializeComponent();
	}

    

    private async void Signin_Clicked(System.Object sender, System.EventArgs e)
    {
		await Shell.Current.GoToAsync(nameof(SignInPage));
    }

    private async void Signup_Clicked(System.Object sender, System.EventArgs e)
    {
		await Shell.Current.GoToAsync(nameof(SignUpPage));
    }
}
