namespace Market_Maui_App;

public partial class ModifyPage : ContentPage
{
    public ModifyPage(ModifyPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}