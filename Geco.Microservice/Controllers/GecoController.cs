using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Geco.Microservice.Data;
using Geco.Microservice.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Geco.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GecoController : ControllerBase
    {
        private readonly ILogger<GecoController> _logger;
        private IApplicationDbContext _context;
        public GecoController(ILogger<GecoController> logger, IApplicationDbContext context)
        {
            _context = context;
            _logger = logger;
        }
        [HttpPost]
        public async Task<IActionResult> Create(Entities.Geco Geco)
        {
            _context.Gecos.Add(Geco);
            await _context.SaveChanges();
            return Ok(Geco.Id);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var customers = await _context.Gecos.ToListAsync();
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
            var Geco = await _context.Gecos.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (Geco == null) return NotFound();
            return Ok(Geco);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var Geco = await _context.Gecos.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (Geco == null) return NotFound();
            _context.Gecos.Remove(Geco);
            await _context.SaveChanges();
            return Ok(Geco.Id);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Entities.Geco gecoData)
        {
            var Geco = _context.Gecos.Where(a => a.Id == id).FirstOrDefault();

            if (Geco == null) return NotFound();
            else
            {
                Geco.CompanyId = gecoData.CompanyId;
                Geco.Month = gecoData.Month;
                Geco.Date = gecoData.Date;
                Geco.Value = gecoData.Value;
                Geco.BU = gecoData.BU;
                await _context.SaveChanges();
                return Ok(Geco.Id);
            }
        }
    }
}
