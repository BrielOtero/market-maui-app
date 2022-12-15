

namespace Market_Maui_App.ViewModel;

[QueryProperty(nameof(Product), "Product")]
public partial class ModifyPageViewModel : BaseViewModel
{
    public ModifyPageViewModel(ProductService productService)
    {
        this.stock = 0;
        this.target = 0;
        this.productService = productService;
    }

    [ObservableProperty]
    Product product;

    ProductService productService;

    [ObservableProperty]
    private string name;
    [ObservableProperty]
    private string image;
    [ObservableProperty]
    private string ref_Alcampo;
    [ObservableProperty]
    private string ref_Carrefour;


    [ObservableProperty]
    private int stock;
    [ObservableProperty]
    private int target;

    [RelayCommand]
    async Task DeStock()
    {
        if (Stock > 0)
            Stock--;
    }

    [RelayCommand]
    async Task InStock()
    {
        Stock++;
    }

    [RelayCommand]
    async Task DeTarget()
    {
        if (Target > 0)
            Target--;
    }

    [RelayCommand]
    async Task InTarget()
    {
        Target++;
    }

    [RelayCommand]
    async Task Add()
    {
        if (String.IsNullOrEmpty(Name) || String.IsNullOrEmpty(Image) || String.IsNullOrEmpty(Ref_Alcampo) || String.IsNullOrEmpty(Ref_Carrefour))
        {
            await Shell.Current.DisplayAlert("Error!", Name + Image + Ref_Alcampo + Ref_Carrefour, "Ok");
            return;
        }

        var product = new Product(Name, Image, Stock, Target, Ref_Alcampo, Ref_Carrefour);
        await productService.PostProduct(product);
    }

    [RelayCommand]
    async Task Apply()
    {
        //if (product == null) return;
        await Shell.Current.GoToAsync(nameof(DetailsPage), true, new Dictionary<string, object>
        {
            {"Product", Product}
        });
    }

    [RelayCommand]
    async Task Back()
    {
        Debug.WriteLine("HOLa");
    }
}
