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
    [JsonPropertyName("ref_alcampo")]
    public string Ref_Alcampo { get; set; }
    [JsonPropertyName("ref_carrefour")]
    public string Ref_Carrefour { get; set; }


    public Product(string name, string image, int stock, int target_Stock, string ref_Alcampo, string ref_Carrefour)
    {
        Name = name;
        Image = image;
        Stock = stock;
        Target_Stock = target_Stock;
        Ref_Alcampo = ref_Alcampo;
        Ref_Carrefour = ref_Carrefour;
    }

    //public Product(int id, string name, string image, int stock, int target_Stock, string ref_Alcampo, string ref_Carrefour)
    //{
    //    Id = id;
    //    Name = name;
    //    Image = image;
    //    Stock = stock;
    //    Target_Stock = target_Stock;
    //    Ref_Alcampo = ref_Alcampo;
    //    Ref_Carrefour = ref_Carrefour;
    //}
}
