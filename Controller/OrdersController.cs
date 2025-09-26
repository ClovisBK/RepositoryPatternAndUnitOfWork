using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Data;
using RepositoryPattern.Dtos.OrderDtos;
using RepositoryPattern.Models;
using RepositoryPattern.Services.UnitOfWorks;

namespace RepositoryPattern.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public OrdersController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var order = await _unitOfWork.Orders.GetAllAsync();
            return Ok(order);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await _unitOfWork.Orders.GetByIdAsync(id);
            return Ok(order);
        }
        [HttpGet("search")]
        public async Task<IActionResult> GetOrdersByOrderDate(DateTime date)
        {
            var order = await _unitOfWork.Orders.GetOrdersByOrderDateAsync(date);
            if (order == null)
                return NotFound();
            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrderDto dto)
        {
            var order =  _mapper.Map<Order>(dto);
            await _unitOfWork.Orders.AddAsync(order);
            await _unitOfWork.SaveChangesAsync();

            var result = _mapper.Map<OrderDto>(order);
            return CreatedAtAction(nameof(GetById),new {id = result.Id}, result );
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateOrderDto updateOrder)
        {
            var order = await _unitOfWork.Orders.GetByIdAsync(id);
            if (order == null)
                return NotFound();
            _mapper.Map(updateOrder, order);

            await _unitOfWork.Orders.UpdateAsync(order);
            await _unitOfWork.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var order = await _unitOfWork.Orders.GetByIdAsync(id);
            if (order == null)
            {
                return NotFound("This order is not found");
            }
          await  _unitOfWork.Orders.DeleteAsync(order);
            await _unitOfWork.SaveChangesAsync();
            return NoContent();
        }
    }
}
