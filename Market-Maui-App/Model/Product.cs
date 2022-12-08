namespace Market_Maui_App.Model;

internal class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Image { get; set; }
    public string Ref_Alcampo { get; set; }
    public string Ref_Carrefour { get; set; }
    public int Stock { get; set; }
    public int TargeStock { get; set; }
}
