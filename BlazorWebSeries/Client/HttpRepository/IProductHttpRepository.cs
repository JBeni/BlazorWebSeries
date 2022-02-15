using BlazorWebSeries.Client.Features;
using BlazorWebSeries.Shared.Entities;
using BlazorWebSeries.Shared.RequestFeatures;

namespace BlazorWebSeries.Client.HttpRepository
{
    public interface IProductHttpRepository
    {
        Task<PagingResponse<Product>> GetProducts(ProductParameters productParameters);
        Task CreateProduct(Product product);
        Task<string> UploadProductImage(MultipartFormDataContent content);
        Task<Product> GetProduct(string id);
        Task UpdateProduct(Product product);
        Task DeleteProduct(Guid id);
    }
}
