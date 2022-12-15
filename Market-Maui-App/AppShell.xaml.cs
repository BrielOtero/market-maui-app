
using Market_Maui_App.View;

namespace Market_Maui_App;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
        Routing.RegisterRoute(nameof(ModifyPage), typeof(ModifyPage));
		Routing.RegisterRoute(nameof(DetailsPage),typeof(DetailsPage));
        Routing.RegisterRoute(nameof(AddPage), typeof(AddPage));
		

    }
}
