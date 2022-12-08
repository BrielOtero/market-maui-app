namespace Market_Maui_App.View;

public partial class MainPage : ContentPage
{

	public MainPage(ProductsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

}

