namespace MAUIApp;
using Auth0.OidcClient;
using MAUIApp.Pages;
using CommunityToolkit.Maui;
using Xe.AcrylicView;
using Microsoft.Extensions.Logging;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseAcrylicView()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				fonts.AddFont("Inter-Light.ttf", "InterLight");
				fonts.AddFont("Inter-Regular.ttf", "InterRegular");
				fonts.AddFont("Inter-Medium.ttf", "InterMedium");
				fonts.AddFont("Inter-SemiBold.ttf", "InterSemiBold");
				fonts.AddFont("Inter-Bold.ttf", "InterBold");
				fonts.AddFont("Inter-ExtraBold.ttf", "InterExtraBold");
				fonts.AddFont("Inter-Black.ttf", "InterBlack");
			})
            .UseMauiCommunityToolkit()
            ;

        builder.Services.AddSingleton<OnboardingPage>();

        builder.Services.AddSingleton(new Auth0Client(new()
        {
            Domain = "dev-iyhvquwxz0pywef8.us.auth0.com",
            ClientId = "e4UGYJQnRWejsW5urUq6fU8rGT35mPrD",
            RedirectUri = "myapp://callback/",
            PostLogoutRedirectUri = "myapp://callback/",
            Scope = "openid profile email"
        }));

        return builder.Build();
	}
}
