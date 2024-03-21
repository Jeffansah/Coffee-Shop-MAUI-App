namespace MAUIApp;

using CommunityToolkit.Maui;
using Xe.AcrylicView;
using MAUIApp.Services;
using MAUIApp.ViewModels;
using MAUIApp.Pages;

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

		AddCoffeeServices(builder.Services);

		return builder.Build();
	}

	private static IServiceCollection AddCoffeeServices(IServiceCollection services)
	{
		services.AddSingleton<CoffeeService>();
		services.AddSingletonWithShellRoute<HomePage, HomeViewModel>(nameof(HomePage));
		return services;
	}
}
