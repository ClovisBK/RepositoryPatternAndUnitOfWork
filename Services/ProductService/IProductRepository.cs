using System.Linq.Expressions;
using RepositoryPattern.Models;
using RepositoryPattern.Services.Repositories;

namespace RepositoryPattern.Services.ProductService
{
    public interface IProductRepository<T> : IRepository<Product> where T : class
    {
        Task<IEnumerable<Product>> GetProductsByNameAsync(string name);
    }
}
