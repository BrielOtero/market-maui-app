namespace Market_Maui_App;

public partial class DetailsPage : ContentPage
{
    public DetailsPage(DetailsPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}