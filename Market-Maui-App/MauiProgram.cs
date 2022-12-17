using CommunityToolkit.Maui;
using Market_Maui_App.View;

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
		builder.Services.AddSingleton<MainPageViewModel>();
		builder.Services.AddSingleton<MainPage>();

		builder.Services.AddTransient<DetailsPageViewModel>();
        builder.Services.AddTransient<AddPageViewModel>();
        builder.Services.AddTransient<ModifyPageViewModel>();
        builder.Services.AddTransient<DetailsPage>();
        builder.Services.AddTransient<AddPage>();
        builder.Services.AddTransient<ModifyPage>();


        return builder.Build();
	}
}
