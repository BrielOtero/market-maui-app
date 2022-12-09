
namespace Market_Maui_App.ViewModel;

[QueryProperty(nameof(Product), "Product")]
public partial class ProductDetailsViewModel : BaseViewModel
{
    public  ProductDetailsViewModel() { }

    [ObservableProperty]
    Product product;

  
}
