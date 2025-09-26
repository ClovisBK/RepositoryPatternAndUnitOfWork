using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Data;
using RepositoryPattern.Models;
using RepositoryPattern.Services.Repositories;
using System.Linq.Expressions;

namespace RepositoryPattern.Services.ProductService
{
    public class ProductRepository<T> : Repository<Product>, IProductRepository<T> where T : class
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProductsByNameAsync(string name)
        {
            return await _context.Products
                .Where(p => p.Name.Contains(name))
                .ToListAsync();
        }
    }
}
