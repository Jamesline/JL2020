using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forecast.Microservice.Data;
using Forecast.Microservice.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Forecast.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForecastController : ControllerBase
    {
        private readonly ILogger<ForecastController> _logger;
        private IApplicationDbContext _context;

        public ForecastController(ILogger<ForecastController> logger, IApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var coges = await _context.Coges.ToListAsync();
            if (coges == null) return NotFound();
            return Ok(coges);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Entities.Coge coge)
        {
            _context.Coges.Add(coge);
            await _context.SaveChanges();
            return Ok(coge.Id);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var coge = await _context.Coges.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (coge == null) return NotFound();
            return Ok(coge);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var coge    = await _context.Coges.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (coge == null) return NotFound();
            _context.Coges.Remove(coge);
            await _context.SaveChanges();
            return Ok(coge.Id);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Entities.Coge cogeData)
        {
            var coge = _context.Coges.Where(a => a.Id == id).FirstOrDefault();

            if (coge == null) return NotFound();
            else
            {
                coge.Date = cogeData.Date;
                coge.Month = cogeData.Month;
                coge.CompanyId = cogeData.CompanyId;
                coge.Value = cogeData.Value;
                coge.BU = cogeData.BU;
                await _context.SaveChanges();
                return Ok(coge.Id);
            }
        }
    }
}
