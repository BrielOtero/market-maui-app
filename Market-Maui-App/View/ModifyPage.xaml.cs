namespace Market_Maui_App;

public partial class ModifyPage : ContentPage
{
    private ModifyPageViewModel vm => BindingContext as ModifyPageViewModel;
    public ModifyPage(ModifyPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await vm.LoadValues();
    }
}