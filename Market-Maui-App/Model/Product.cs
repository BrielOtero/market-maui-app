using System.Text.Json.Serialization;

namespace Market_Maui_App.Model;

public class Product
{
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("image")]
    public string Image { get; set; }
    [JsonPropertyName("stock")]
    public int Stock { get; set; }
    [JsonPropertyName("target_stock")]
    public int Target_Stock { get; set; }
    [JsonPropertyName("ref_alcampo")]
    public string Ref_Alcampo { get; set; }
    [JsonPropertyName("ref_carrefour")]
    public string Ref_Carrefour { get; set; }

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
