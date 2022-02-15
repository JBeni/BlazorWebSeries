﻿using BlazorWebSeries.Server.Context;
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

        public async Task<Product> GetProduct(Guid id) =>
            await _context.Products.FirstOrDefaultAsync(p => p.Id.Equals(id));

        public async Task UpdateProduct(Product product, Product dbProduct)
        {
            dbProduct.Name = product.Name;
            dbProduct.Price = product.Price;
            dbProduct.ImageUrl = product.ImageUrl;
            dbProduct.Supplier = product.Supplier;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteProduct(Product product)
        {
            _context.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}
