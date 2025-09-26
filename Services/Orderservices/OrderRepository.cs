using System.Collections;
using System.Linq.Expressions;
using System.Numerics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Data;
using RepositoryPattern.Models;
using RepositoryPattern.Services.Repositories;

namespace RepositoryPattern.Services.Orderservices
{
    public class OrderRepository<T> : Repository<Order>, IOrderRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        public OrderRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetOrdersByOrderDateAsync(DateTime orderDate)
        {
            return await _context.Orders
                .Include(c => c.Customer)
                .Include(p => p.Product)
                .Where(p => p.OrderDate == orderDate).ToListAsync();
        }
    }
}
