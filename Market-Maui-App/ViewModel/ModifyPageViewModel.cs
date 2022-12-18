

namespace Market_Maui_App.ViewModel;

[QueryProperty(nameof(Product), "Product")]
public partial class ModifyPageViewModel : BaseViewModel
{
    public ModifyPageViewModel(ProductService productService)
    {
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
    internal async Task LoadValues()
    {
        this.Name = Product.Name;
        this.Image = Product.Image;
        this.Stock = Product.Stock;
        this.Target = Product.Target_Stock;
        this.Quantity = Product.Quantity;
        this.Measurement = Product.Measurement;
        this.Ref_Alcampo = Product.Ref_Alcampo;
        this.Quantity_Alcampo = Product.Quantity_Alcampo;
        this.Ref_Carrefour = Product.Ref_Carrefour;
        this.Quantity_Carrefour = Product.Quantity_Carrefour;
    }

    [RelayCommand]
    async Task Apply()
    {
        if (String.IsNullOrEmpty(Name) || String.IsNullOrEmpty(Image) ||  String.IsNullOrEmpty(Ref_Alcampo)|| Double.IsNaN(Quantity_Alcampo) || String.IsNullOrEmpty(Ref_Carrefour)|| Double.IsNaN(Quantity_Carrefour))
        {
            await Shell.Current.DisplayAlert("Error!", "Fill the fields ", "Ok");
            return;
        }
        var product = new Product(Name, Image, Stock, Target,Quantity,Measurement, Ref_Alcampo,Quantity_Alcampo, Ref_Carrefour,Quantity_Carrefour);
        await productService.UpdateProduct(product,Product.Id);
        await Shell.Current.GoToAsync("..", true);
    }

}
