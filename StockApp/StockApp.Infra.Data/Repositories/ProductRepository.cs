using Microsoft.EntityFrameworkCore;
using StockApp.Domain.Entities;
using StockApp.Domain.Interfaces;
using StockApp.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockApp.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _productContext;

        public ProductRepository(ApplicationDbContext context)
        {
            _productContext = context;
        }

        public async Task<Product> Create(Product product)
        {
            _productContext.Products.Add(product);
            await _productContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> GetById(int? id)
        {
            var product = await _productContext.Products.FindAsync(id);
            return product;
        }

        public async Task<IEnumerable<Product>> GetProductAsync()
        {
            return await _productContext.Products.OrderBy(p => p.Name).ToListAsync();
        }

        public async Task<Product> Update(Product product)
        {
            _productContext.Products.Update(product);
            await _productContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> Remove(Product product)
        {
            _productContext.Products.Remove(product);
            await _productContext.SaveChangesAsync();
            return product;
        }

        public Task<Product> GetId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
