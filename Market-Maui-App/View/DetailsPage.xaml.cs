namespace Market_Maui_App;

public partial class DetailsPage : ContentPage
{
    public DetailsPage(ProductDetailsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}