using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using RepositoryPattern.Data;
using RepositoryPattern.Models;
using RepositoryPattern.Services.Repositories;

namespace RepositoryPattern.Services.CustomerService
{
    public class CustomerRepository<T> : Repository<Customer>, ICustomerRepository<T> where T : class
    {
       
        private readonly AppDbContext _context;

        public CustomerRepository(AppDbContext context) : base(context) 
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetCustomersByNameAsync(string customerName)
        {
            return await _context.Customers
                .Where(c => c.Name.Contains(customerName))
                .ToListAsync();
        }
    }
}
