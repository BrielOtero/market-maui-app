namespace Market_Maui_App;

public partial class AddPage : ContentPage
{
	public AddPage(ProductAddViewModel viewModel)
	{
		InitializeComponent();
		BindingContext= viewModel;
		
	}
}