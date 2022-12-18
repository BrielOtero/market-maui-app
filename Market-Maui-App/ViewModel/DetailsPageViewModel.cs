

namespace Market_Maui_App.ViewModel;

[QueryProperty(nameof(Product), "Product")]
public partial class DetailsPageViewModel : BaseViewModel
{
    ProductService productService;

    public DetailsPageViewModel(ProductService productService)
    {
        this.productService = productService;
    }

    [ObservableProperty]
    Product product;


    [RelayCommand]
    async Task Decrease()
    {
        Product pro = new Product(Product.Name, Product.Image, Product.Stock - 1, Product.Target_Stock,Product.Quantity,Product.Measurement, Product.Ref_Alcampo,Product.Quantity_Alcampo, Product.Ref_Carrefour,Product.Quantity_Carrefour);
        pro.Id = Product.Id;
        Product = pro;
        await productService.DecreaseStock(Product);
    }

}
