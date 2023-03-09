using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Authorize(Roles = "ADMIN")]
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private DbRestaurantContext _context;
        public MemberController(DbRestaurantContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.Members.Select(m => new
            {
                Id = m.MemberId,
                Name = m.Name,
                Email = m.Email,
                Handphone = m.Handphone,
                JoinDate = m.Joindate
            }).ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAt(int id)
        {
            var member = await _context.Members.FindAsync(id);
            return Ok(member);
        }
        [HttpPost]
        public async Task<IActionResult> Post(Member request)
        {
            _context.Members.Add(request);
            await _context.SaveChangesAsync();
            return Ok(await _context.Members.Select(m => new
            {
                Id = m.MemberId,
                Name = m.Name,
                Email = m.Email,
                Handphone = m.Handphone,
                JoinDate = m.Joindate
            }).ToListAsync());
        }
        [HttpPut]
        public async Task<IActionResult> Put(Member request)
        {
            int id = request.MemberId;
            var member = await _context.Members.FindAsync(id);
            if (member == null)
                return BadRequest("member not found.");
            member.Name = request.Name;
            member.Email = request.Email;
            member.Handphone = request.Handphone;

            await _context.SaveChangesAsync();

            return Ok("success");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var member = await _context.Members.FindAsync(id);
            if (member == null)
            {
                return BadRequest("member not found");
            }
            _context.Members.Remove(member);
            await _context.SaveChangesAsync();
            return Ok("success");
        }
    }
}
