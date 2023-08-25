using JobSearch.API.Database;
using JobSearch.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobSearch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DatabaseContext _databaseContext;
        public UsersController(DatabaseContext db)
        {
            _databaseContext = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetUser(string email, string password)
        {
            User? user = await _databaseContext.Users.FirstOrDefaultAsync(user => user.Email == email && user.Password == password);

            if (user == null)
            {
                return NotFound();
            }

            return new JsonResult(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(User user)
        {
            var newUser = await _databaseContext.AddAsync(user);

            if (newUser == null)
            {
                return BadRequest("Erro ao criar usuario");
            }

            await _databaseContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUser), new { 
                email = newUser.Entity.Email, 
                password = newUser.Entity.Password 
            }, newUser.Entity);

        }

    }
}
