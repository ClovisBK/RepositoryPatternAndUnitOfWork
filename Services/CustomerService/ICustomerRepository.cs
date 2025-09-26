using System.Linq.Expressions;
using RepositoryPattern.Models;
using RepositoryPattern.Services.Repositories;

namespace RepositoryPattern.Services
{
    public interface ICustomerRepository<T> : IRepository<Customer> where T : class
    {
      Task<IEnumerable<Customer>> GetCustomersByNameAsync(string customerName);
    }
}
