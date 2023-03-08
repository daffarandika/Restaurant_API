using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private DbRestaurantContext _context;
        public EmployeeController(DbRestaurantContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.Employees.Select(emp => new
            {
                Id = emp.EmployeeId,
                Name = emp.Name,
                Email = emp.Email,
                Handphone = emp.Handphone,
                Position = emp.Position,
            }).ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAt(int id)
        {
            var employees = await _context.Employees.FindAsync(id);
            return Ok(employees);
        }
        [HttpPost]
        public async Task<IActionResult> Post(Employee request)
        {
            _context.Employees.Add(request);
            await _context.SaveChangesAsync();
            return Ok(await _context.Employees.Select(emp => new
            {
                Id = emp.EmployeeId,
                Name = emp.Name,
                Email = emp.Email,
                Handphone = emp.Handphone,
                Position = emp.Position,
            }).ToListAsync());
        }
        [HttpPut]
        public async Task<IActionResult> Put(Employee request)
        {
            int id = request.EmployeeId;
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
                return BadRequest("Employee not found.");
            employee.Name = request.Name;
            employee.Email = request.Email;
            employee.Password = request.Password;
            employee.Handphone = request.Handphone;
            employee.Position = request.Position;

            await _context.SaveChangesAsync();

            return Ok("success");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return BadRequest("Employee not found");
            }
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return Ok("success");
        }
    }
}
