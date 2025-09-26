using RepositoryPattern.Models;
using RepositoryPattern.Services.CustomerService;
using RepositoryPattern.Services.Orderservices;
using RepositoryPattern.Services.ProductService;

namespace RepositoryPattern.Services.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository<Product> Products { get; }
        ICustomerRepository<Customer> Customers { get; }
        IOrderRepository<Order> Orders { get; }
        Task<int> SaveChangesAsync();
    }
}
