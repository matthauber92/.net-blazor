using BlazorApp.Domain;
using BlazorApp.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repo;

        public ProductsController(IProductRepository repo)
        {
            _repo = repo;
        }

        // GET: api/products/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var product = await _repo.GetByIdAsync(id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }

        // POST: api/products
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Product product)
        {
            await _repo.AddAsync(product);
            await _repo.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }
    }
}
