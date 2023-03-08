using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private DbRestaurantContext _context;
        public OrderController(DbRestaurantContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult<List<OrderDTO>> Get(string? member)
        {
            if (member != null)
            {
                return Ok(_context.Headorders.Where(h => h.Member.Name.Contains(member)).Select(h => new OrderDTO
                {
                    orderID = h.OrderId,
                    member = h.Member.Name,
                    employee = h.Employee.Name,
                    payment = h.Payment,
                    bank = h.Bank,
                    date = h.Date,
                    orders = h.Detailorders.Where(d => d.OrderId == h.OrderId).Select(d => new DetailorderDTO
                    {
                        menu = d.Menu.Name,
                        qty = d.Qty,
                        price = d.Price
                    }).ToList()
                }));
            }
            return Ok(_context.Headorders.Select(h => new OrderDTO
            {
                orderID = h.OrderId,
                member = h.Member.Name,
                employee = h.Employee.Name,
                payment = h.Payment,
                bank = h.Bank,
                date = h.Date,
                orders = h.Detailorders.Where(d => d.OrderId == h.OrderId).Select(d => new DetailorderDTO
                {
                    menu = d.Menu.Name,
                    qty = d.Qty,
                    price = d.Price
                }).ToList()
            }));
        }
    }
}
