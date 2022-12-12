
using Market_Maui_App.Services;

namespace Market_Maui_App.ViewModel;

[QueryProperty(nameof(Product), "Product")]
public partial class ProductDetailsViewModel : BaseViewModel
{
    public ProductDetailsViewModel(ProductService productService)
    {
        this.productService = productService;
    }
    ProductService productService;

    [ObservableProperty]
    Product product;


    [RelayCommand]
    async Task Decrease()
    {
        Debug.WriteLine(Product.Id);
        Product.Stock = Product.Stock - 1;
        await productService.DecreaseStock(Product);
    }


}
