using BlazorWebSeries.Server.Context;
using BlazorWebSeries.Server.Paging;
using BlazorWebSeries.Server.Repository.RepositoryExtensions;
using BlazorWebSeries.Shared.Entities;
using BlazorWebSeries.Shared.RequestFeatures;
using Microsoft.EntityFrameworkCore;

namespace BlazorWebSeries.Server.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _context;

        public ProductRepository(ProductContext context)
        {
            _context = context;
        }

        public async Task<PagedList<Product>> GetProducts(ProductParameters productParameters)
        {
            var products = await _context.Products
                .Search(productParameters.SearchTerm)
                .Sort(productParameters.OrderBy)
                .ToListAsync();

            return PagedList<Product>
                .ToPagedList(products, productParameters.PageNumber, productParameters.PageSize);
        }

        public async Task CreateProduct(Product product)
        {
            _context.Add(product);
            await _context.SaveChangesAsync();
        }
    }
}
