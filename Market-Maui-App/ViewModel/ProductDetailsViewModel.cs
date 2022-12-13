namespace Market_Maui_App.ViewModel;

[QueryProperty(nameof(Product), "Product")]
public partial class ProductDetailsViewModel : BaseViewModel
{
    ProductService productService;

    public ProductDetailsViewModel(ProductService productService)
    {
        this.productService = productService;
    }

    [ObservableProperty]
    Product product;


    [RelayCommand]
    async Task Decrease()
    {
        Product pro = new Product(Product.Name, Product.Image, Product.Stock - 1, Product.Target_Stock, Product.Ref_Alcampo, Product.Ref_Carrefour);
        pro.Id = Product.Id;
        Product = pro;
        await productService.DecreaseStock(Product);
    }


}
