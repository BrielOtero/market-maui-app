using CommunityToolkit.Maui;
using Market_Maui_App.Services;
using Market_Maui_App.View;
using Microsoft.Extensions.Logging;

namespace Market_Maui_App;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
		builder.Services.AddSingleton<ProductService>();
		builder.Services.AddSingleton<ProductsViewModel>();
		builder.Services.AddSingleton<MainPage>();

		builder.Services.AddTransient<ProductDetailsViewModel>();
        builder.Services.AddTransient<ProductAddViewModel>();
        builder.Services.AddTransient<DetailsPage>();
        builder.Services.AddTransient<AddPage>();


        return builder.Build();
	}
}
