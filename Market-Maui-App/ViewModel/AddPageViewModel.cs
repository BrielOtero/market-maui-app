

namespace Market_Maui_App.ViewModel;
public partial class AddPageViewModel : BaseViewModel
{
    public AddPageViewModel(ProductService productService)
    {
        this.stock = 0;
        this.target = 0;
        this.productService = productService;
    }

    ProductService productService;

    [ObservableProperty]
    private string name;
    [ObservableProperty]
    private string image;
    [ObservableProperty]
    private int stock;
    [ObservableProperty]
    private int target;
    [ObservableProperty]
    private double quantity;
    [ObservableProperty]
    private string measurement;
    [ObservableProperty]
    private string ref_Alcampo;
    [ObservableProperty]
    private double quantity_Alcampo;
    [ObservableProperty]
    private string ref_Carrefour;
    [ObservableProperty]
    private double quantity_Carrefour;

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
        if (String.IsNullOrEmpty(Name) || String.IsNullOrEmpty(Image) || String.IsNullOrEmpty(Ref_Alcampo) || Double.IsNaN(Quantity_Alcampo) || String.IsNullOrEmpty(Ref_Carrefour) || Double.IsNaN(Quantity_Carrefour))
        {
            await Shell.Current.DisplayAlert("Error!", "Fill the fields", "Ok");
            return;
        }

        var product = new Product(Name, Image, Stock, Target, Quantity, Measurement, Ref_Alcampo, Quantity_Alcampo, Ref_Carrefour, Quantity_Carrefour);
        await productService.PostProduct(product);
        await Shell.Current.GoToAsync("..", true);
    }
}
