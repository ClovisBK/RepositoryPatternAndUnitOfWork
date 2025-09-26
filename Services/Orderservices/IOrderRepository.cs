using System.Linq.Expressions;
using RepositoryPattern.Models;
using RepositoryPattern.Services.Repositories;

namespace RepositoryPattern.Services.Orderservices
{
    public interface IOrderRepository<T> : IRepository<Order> where T : class
    {
            Task<IEnumerable<Order>> GetOrdersByOrderDateAsync(DateTime orderDate);
    }
}
