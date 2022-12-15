namespace Market_Maui_App.View;

public partial class MainPage : ContentPage
{
	private MainPageViewModel vm => BindingContext as MainPageViewModel;
	public MainPage(MainPageViewModel viewModel)
	{
		InitializeComponent();
		viewModel.GetProductsCommand.Execute(this);
		BindingContext = viewModel;
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await vm.InitializeAsync();
    }

}

