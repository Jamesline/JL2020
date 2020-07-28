using System.Linq;
using System.Threading.Tasks;
using Customer.Microservice.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Customer.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private IApplicationDbContext _context;
        public CustomerController(ILogger<CustomerController> logger, IApplicationDbContext context)
        {
            _context = context;
            _logger = logger;
        }
        [HttpPost]
        public async Task<IActionResult> Create(Entities.Customer Customer)
        {
            _context.Customers.Add(Customer);
            await _context.SaveChanges();
            return Ok(Customer.Id);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var customers = await _context.Customers.ToListAsync();
                if (customers == null) return NotFound();
                return Ok(customers);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                return Ok(ex.Message);
            }
            
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Customer = await _context.Customers.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (Customer == null) return NotFound();
            return Ok(Customer);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var Customer = await _context.Customers.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (Customer == null) return NotFound();
            _context.Customers.Remove(Customer);
            await _context.SaveChanges();
            return Ok(Customer.Id);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Entities.Customer CustomerData)
        {
            var Customer = _context.Customers.Where(a => a.Id == id).FirstOrDefault();

            if (Customer == null) return NotFound();
            else
            {
                Customer.Name = CustomerData.Name;
                Customer.Contact = CustomerData.Contact;
                await _context.SaveChanges();
                return Ok(Customer.Id);
            }
        }
    }
}
