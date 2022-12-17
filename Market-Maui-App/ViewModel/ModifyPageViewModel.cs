

using Market_Maui_App.View;

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
    internal async Task LoadValues()
    {
        this.Name = Product.Name;
        this.Image = Product.Image;
        this.Stock = Product.Stock;
        this.Target = Product.Target_Stock;
        this.Ref_Alcampo = Product.Ref_Alcampo;
        this.Ref_Carrefour = Product.Ref_Carrefour;
    }

    [RelayCommand]
    async Task Apply()
    {
        if (String.IsNullOrEmpty(Name) || String.IsNullOrEmpty(Image) || String.IsNullOrEmpty(Ref_Alcampo) || String.IsNullOrEmpty(Ref_Carrefour))
        {
            await Shell.Current.DisplayAlert("Error!", Name + Image + Ref_Alcampo + Ref_Carrefour, "Ok");
            return;
        }
        var product = new Product(Name, Image, Stock, Target, Ref_Alcampo, Ref_Carrefour);
        await productService.UpdateProduct(product,Product.Id);
        await Shell.Current.GoToAsync("..", true);
    }

}
