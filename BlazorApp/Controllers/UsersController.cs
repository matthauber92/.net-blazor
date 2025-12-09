using BlazorApp.Domain.Entities;
using BlazorApp.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _repo;

        public UsersController(IUserRepository repo)
        {
            _repo = repo;
        }

        // GET: api/users/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _repo.GetByIdAsync(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        // POST: api/users
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] User user)
        {
            await _repo.AddAsync(user);
            await _repo.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _repo.GetByIdAsync(id);

            if (user == null)
                return NotFound();

            _repo.Delete(user);
            await _repo.SaveChangesAsync();

            return NoContent(); // 204 response
        }

    }
}
