using BlazorWebSeries.Server.Paging;
using BlazorWebSeries.Shared.Entities;
using BlazorWebSeries.Shared.RequestFeatures;

namespace BlazorWebSeries.Server.Repository
{
    public interface IProductRepository
    {
        Task<PagedList<Product>> GetProducts(ProductParameters productParameters);
        Task CreateProduct(Product product);
    }
}
