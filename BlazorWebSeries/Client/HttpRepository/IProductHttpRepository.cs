using BlazorWebSeries.Client.Features;
using BlazorWebSeries.Shared.Entities;
using BlazorWebSeries.Shared.RequestFeatures;

namespace BlazorWebSeries.Client.HttpRepository
{
    public interface IProductHttpRepository
    {
        Task<PagingResponse<Product>> GetProducts(ProductParameters productParameters);
        Task CreateProduct(Product product);
    }
}
