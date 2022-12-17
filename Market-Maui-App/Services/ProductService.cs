
using System.Net.Http.Json;
using System.Text;

namespace Market_Maui_App.Services;

public class ProductService
{
    HttpClient httpClient;
    string apiUrl;

    private List<Product> productList = new();
    public List<Product> ProductList
    {
        get => productList;
        set => productList = value;
    }

    public bool NeedDataRefresh = false;


    public ProductService()
    {
        this.httpClient = new HttpClient();
        apiUrl = "https://market-nodejs-mysql-rest-api-production.up.railway.app/api/products";
    }

    public async Task<List<Product>> GetProducts()
    {
        var response = await httpClient.GetAsync(apiUrl);
        if (response.IsSuccessStatusCode)
        {
            ProductList = await response.Content.ReadFromJsonAsync<List<Product>>();
            NeedDataRefresh = true;
        }

        return ProductList;
    }
    public async Task PostProduct(Product product)
    {
        var payload = JsonSerializer.Serialize(product);
        StringContent content = new StringContent(payload, Encoding.UTF8, "application/json");
        var response = await httpClient.PostAsync(apiUrl, content);
        if (response.IsSuccessStatusCode)
        {
            ProductList.Add(product);
            NeedDataRefresh = true;
        }
    }
    public async Task DecreaseStock(Product product)
    {
        string payload = $"{{\"stock\":{product.Stock}}}";
        StringContent content = new StringContent(payload, Encoding.UTF8, "application/json");

        var response = await httpClient.PatchAsync($"{apiUrl}/{product.Id}", content);

        if (response.IsSuccessStatusCode)
        {
            var item = productList.Find(x => x.Id == product.Id);
            ProductList[productList.IndexOf(item)].Stock = product.Stock;
            NeedDataRefresh = true;
        }

    }

    public async Task UpdateProduct(Product product, int id)
    {
        var payload = JsonSerializer.Serialize(product);
        StringContent content = new StringContent(payload, Encoding.UTF8, "application/json");

        var response = await httpClient.PatchAsync($"{apiUrl}/{id}", content);

        if (response.IsSuccessStatusCode)
        {
            var item = productList.Find(x => x.Id == id);
            var index = productList.IndexOf(item);
            ProductList[index] = product;
            ProductList[index].Id = id;
            NeedDataRefresh = true;
        }
    }
}

