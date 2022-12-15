namespace Market_Maui_App.ViewModel;

public partial class MainPageViewModel : BaseViewModel
{
    ProductService productService;
    public ObservableCollection<Product> Products { get; set; } = new();
    public MainPageViewModel(ProductService productService)
    {
        Title = "Market";
        this.productService = productService;
        GetProductsAsync();
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

    [RelayCommand]
    async Task GoToAdd()
    {
        await Shell.Current.GoToAsync(nameof(AddPage), true);
    }

    internal async Task InitializeAsync()
    {
        await GetProductsAsync();
    }

}
