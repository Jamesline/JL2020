using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Company.Microservice.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Company.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private IApplicationDbContext _context;
        public CompanyController(IApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Create(Entities.Company company)
        {
            _context.Companies.Add(company);
            await _context.SaveChanges();
            return Ok(company.Id);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _context.Companies.ToListAsync();
            if (customers == null) return NotFound();
            return Ok(customers);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var company = await _context.Companies.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (company == null) return NotFound();
            return Ok(company);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var company = await _context.Companies.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (company == null) return NotFound();
            _context.Companies.Remove(company);
            await _context.SaveChanges();
            return Ok(company.Id);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Entities.Company companyData)
        {
            var company = _context.Companies.Where(a => a.Id == id).FirstOrDefault();

            if (company == null) return NotFound();
            else
            {
                company.Name = companyData.Name;
                company.Contact = companyData.Contact;
                await _context.SaveChanges();
                return Ok(company.Id);
            }
        }
    }
}
