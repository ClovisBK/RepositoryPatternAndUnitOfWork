using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Dtos.ProductDtos;
using RepositoryPattern.Models;
using RepositoryPattern.Services.UnitOfWorks;

namespace RepositoryPattern.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public ProductsController(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

     
        [HttpGet, Authorize]
        public async Task<IActionResult> Get() => Ok(await _uow.Products.GetAllAsync());


        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var product = await _uow.Products.GetByIdAsync(id);
            if (product == null)
                return NotFound();
            return Ok(product); 
        }
        
        [HttpGet("search"), Authorize]
        public async Task<IActionResult> GetProductByName(string name)
        {
            var product = await _uow.Products.GetProductsByNameAsync(name);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        [HttpGet("Search-by-price")]
        public async Task<IActionResult> ProductPrice(decimal price)
        {
            var product = await _uow.Products.ProductPriceRange(price);
            if(product == null)
                return NotFound();
                return Ok(produc);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductDto dto)
        {
            var product = _mapper.Map<Product>(dto);

            await _uow.Products.AddAsync(product);
            await _uow.SaveChangesAsync();  

           var result = _mapper.Map<ProductDto>(product);

            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateProductDto updateProductDto)
        {
            var product = await _uow.Products.GetByIdAsync(id);
            if (product == null) return NotFound();

            _mapper.Map(updateProductDto, product);

           await _uow.Products.UpdateAsync(product);
            await _uow.SaveChangesAsync();

            return NoContent();
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var prod = await _uow.Products.GetByIdAsync(id);
            if(prod == null) return NotFound();
            await _uow.Products.DeleteAsync(prod);
            await _uow.SaveChangesAsync();
            return NoContent();
        }
    }
}
