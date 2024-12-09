using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIMag.Models;

namespace APIMag.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly EnvironmentalMonitoringContext _context;

        public UserController(EnvironmentalMonitoringContext context)
        {
            _context = context;
        }
        // GET: api/user
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/user/{id}
        [HttpGet("{Id}")]
        public async Task<ActionResult<User>> GetById(int Id)
        {
            var users = await _context.Users.FindAsync(Id);
            if (users is null)
                return NotFound();

            return users;
        }

        // POST: api/users
        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            try
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetById), new { Id = user.UserId }, user);
            }
            catch (DbUpdateException)
            {
                // Обработка исключения
                return BadRequest("Ошибка при создании Пользователя.");
            }
        }

        // PUT: api/users/{id}
        [HttpPut("{Id}")]
        public async Task<IActionResult> PutUser(int Id, User user)
        {
            if (Id != user.UserId)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool UserExists(int Id)
        {
            return _context.Users.Any(e => e.UserId == Id);
        }

        // DELETE: api/user/{id}
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteUser(int Id)
        {
            var user = await _context.Users.FindAsync(Id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        
    }
}
