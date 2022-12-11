using System.Text.Json.Serialization;

namespace Market_Maui_App.Model;

public class Product
{
    [JsonIgnore]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Image { get; set; }
    public string Ref_Alcampo { get; set; }
    public string Ref_Carrefour { get; set; }
    public int Stock { get; set; }
    public int Target_Stock { get; set; }

    public Product(string name, string image, string ref_Alcampo, string ref_Carrefour, int stock, int target_Stock)
    {
        Name = name;
        Image = image;
        Ref_Alcampo = ref_Alcampo;
        Ref_Carrefour = ref_Carrefour;
        Stock = stock;
        Target_Stock = target_Stock;
    }
}
