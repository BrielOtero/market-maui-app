using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Market_Maui_App.ViewModel;

public partial class MainPageViewModel : BaseViewModel
{
    ProductService productService;

    private List<Product> products;
    public List<Product> Products
    {
        get => products;
        set => products = value;
    }

    public MainPageViewModel(ProductService productService)
    {
        Title = "Market";
        products = new();
        this.productService = productService;
        GetProductsAsync();
        ProductsFilter = Products.ToObservableCollection();
    }

    [ObservableProperty]
    bool isRefreshing;

    [ObservableProperty]
    ObservableCollection<Product> productsFilter = new();


    [RelayCommand]
    async Task GetProductsAsync()
    {
        if (IsBusy) return;

        try
        {
            IsBusy = true;

            var products = await productService.GetProducts();

            Products = products;
            ProductsFilter = products.ToObservableCollection();
            productService.NeedDataRefresh = false;
            SearchText = "";


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
    async Task GoToModify(Product product)
    {
        if (product == null) return;

        await Shell.Current.GoToAsync(nameof(ModifyPage), true, new Dictionary<string, object>
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

        if (productService.ProductList == null)return;

        if (productService.NeedDataRefresh)
        {
            Products = productService.ProductList;
            ProductsFilter = productService.ProductList.ToObservableCollection();
            productService.NeedDataRefresh = false;
        }
    }

    [RelayCommand]
    async Task Search()
    {
        var searchResult = Products.Where(x => x.Name.ToLower().Contains(SearchText));

        if (searchResult.Count() > 0)
        {
            ProductsFilter = searchResult.ToObservableCollection();
        }
    }

    private string searchText;
    public string SearchText
    {
        get
        {
            return searchText;
        }
        set
        {
            searchText = value;
            if (searchText.Length > 0)
            {
                Task.Run(async () => { await Search(); }).Wait();
            }
            if (searchText == "")
            {

                ProductsFilter = Products.ToObservableCollection();
            }
        }
    }

}
