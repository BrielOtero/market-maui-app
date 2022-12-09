
using Market_Maui_App.Services;

namespace Market_Maui_App.ViewModel;

public partial class ProductsViewModel : BaseViewModel
{
    ProductService productService;
    public ObservableCollection<Product> Products { get; set; } = new();
    public ProductsViewModel(ProductService productService)
    {
        Title = "Market";
        this.productService = productService;
    }

    [ObservableProperty]
    bool isRefreshing;


    [RelayCommand]
    async Task GetProductsAsync()
    {
        if (IsBusy) return;

        try
        {
            IsBusy = true;

            var products = await productService.GetProducts();

            if (Products.Count != 0)
                Products.Clear();

            foreach (var product in products)
                Products.Add(product);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("Error!", "Unable to get products", "Ok");
        }
        finally
        {
            IsBusy = false;
            IsRefreshing = false;

        }
    }

    [RelayCommand]
    async Task GoToDetails(Product product)
    {
        if (product == null) return;

        await Shell.Current.GoToAsync(nameof(DetailsPage), true, new Dictionary<string, object>
        {
            {"Product",product }
        });
    }
}
