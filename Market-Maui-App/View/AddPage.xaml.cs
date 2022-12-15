namespace Market_Maui_App;

public partial class AddPage : ContentPage
{
	public AddPage(AddPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext= viewModel;
		
	}
}