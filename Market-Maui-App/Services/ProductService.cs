
using System.Net.Http.Json;
using System.Text;

namespace Market_Maui_App.Services;

public class ProductService
{
    HttpClient httpClient;

    public ProductService()
    {
        this.httpClient = new HttpClient();
    }

    List<Product> productList;

    public async Task<List<Product>> GetProducts()
    {
        var response = await httpClient.GetAsync("https://market-nodejs-mysql-rest-api-production.up.railway.app/api/products");
        if (response.IsSuccessStatusCode)
        {
            productList = await response.Content.ReadFromJsonAsync<List<Product>>();
        }

        return productList;
    }
    public async Task NewProduct(Product product)
    {
        var payload = JsonSerializer.Serialize(product);
        StringContent content = new StringContent(payload, Encoding.UTF8, "application/json");
        Debug.WriteLine(content.ToString());
        await httpClient.PostAsync("https://market-nodejs-mysql-rest-api-production.up.railway.app/api/products",content);
      

    }
}
