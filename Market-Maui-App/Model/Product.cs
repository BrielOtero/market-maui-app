using System.Text.Json.Serialization;
using System.Xml.Linq;

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

    [JsonPropertyName("quantity")]
    public double Quantity { get; set; }

    [JsonPropertyName("measurement")]
    public string Measurement { get; set; }

    [JsonPropertyName("ref_alcampo")]
    public string Ref_Alcampo { get; set; }

    [JsonPropertyName("quantity_alcampo")]
    public double Quantity_Alcampo { get; set; }

    [JsonPropertyName("ref_carrefour")]
    public string Ref_Carrefour { get; set; }

    [JsonPropertyName("quantity_carrefour")]
    public double Quantity_Carrefour { get; set; }



    public Product(string name, string image, int stock, int target_Stock, double quantity, string measurement, string ref_Alcampo, double quantity_Alcampo, string ref_Carrefour, double quantity_Carrefour)
    {
        Name = name;
        Image = image;
        Stock = stock;
        Quantity = quantity;
        Target_Stock = target_Stock;
        Measurement = measurement;
        Ref_Alcampo = ref_Alcampo;
        Quantity_Alcampo = quantity_Alcampo;
        Ref_Carrefour = ref_Carrefour;
        Quantity_Carrefour = quantity_Carrefour;
    }

}
