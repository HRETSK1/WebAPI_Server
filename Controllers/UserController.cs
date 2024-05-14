using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net.WebSockets;
using System.Text.Json.Serialization;
using WebAPI_Server.DA;
using WebAPI_Server.Domain;

namespace WebAPI_Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private UserContext _userContext;

        public UserController(UserContext userContext)
        {
            _userContext = userContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllAsync()
        {
            return await _userContext.Users.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync(User user)
        {
            _userContext.Add(user);
            await _userContext.SaveChangesAsync();
            return Ok(user);
        }


        [HttpPut]
        public async Task<ActionResult<User>> EditAsync(User user)
        {
            if (!_userContext.Users.Any(x => x.Id == user.Id))
            {
                return NotFound();
            }

            _userContext.Update(user);
            await _userContext.SaveChangesAsync();
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var user = _userContext.Users.FirstOrDefault(x => x.Id == id);

            if (user == null)
            {
                return BadRequest();
            }

            _userContext.Users.Remove(user);
            await _userContext.SaveChangesAsync();
            return Ok();
        }
    }
}
