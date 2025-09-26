using RepositoryPattern.Data;
using RepositoryPattern.Models;
using RepositoryPattern.Services.CustomerService;
using RepositoryPattern.Services.Orderservices;
using RepositoryPattern.Services.ProductService;

namespace RepositoryPattern.Services.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly AppDbContext _context;
        public IProductRepository<Product> Products { get; }
        public ICustomerRepository<Customer> Customers { get; }
        public IOrderRepository<Order> Orders { get; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Orders = new OrderRepository<Order>(context);
            Products = new ProductRepository<Product>(context);
            Customers = new CustomerRepository<Customer>(context);
        }
        //public IProductRepository<Product> Products => _productRepository ??= new ProductRepository<Product>(_context);

        //public ICustomerRepository<Customer> Customers => _customerRepository ??= new CustomerRepository<Customer>(_context);
        //public IOrderRepository<Order> Orders => _orderRepository ??= new OrderRepository<Order>(_context)

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();    
      

    }
}
