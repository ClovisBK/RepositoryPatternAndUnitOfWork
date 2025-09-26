using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Dtos.CustomerDtos;
using RepositoryPattern.Models;
using RepositoryPattern.Services.UnitOfWorks;

namespace RepositoryPattern.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CustomersController(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _uow.Customers.GetAllAsync());

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var existing = await _uow.Customers.GetByIdAsync(id);
            if (existing == null) return NotFound();
            return Ok(existing);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetCustomerByName(string name)
        {
            var customer = await _uow.Customers.GetCustomersByNameAsync(name);

            return Ok(customer);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCustomerDto customerDto)
        {
           var customer = _mapper.Map<Customer>(customerDto);
            await _uow.Customers.AddAsync(customer);
            await _uow.SaveChangesAsync();

            var result = _mapper.Map<CustomerDto>(customer);
            return CreatedAtAction(nameof(GetById), new {id = result.Id}, result);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCustomerDto updateCustomer)
        {
            var existing = await _uow.Customers.GetByIdAsync(id);
            if (existing == null) return NotFound();

            _mapper.Map(updateCustomer, existing);
          
            await _uow.Customers.UpdateAsync(existing);
            await _uow.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _uow.Customers.GetByIdAsync(id);
            if (existing == null) return NotFound();
           await _uow.Customers.DeleteAsync(existing);
            await _uow.SaveChangesAsync();
            return NoContent();
        }
    }
}
