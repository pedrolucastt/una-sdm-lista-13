using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmericanAirlinesApi.Data;
using AmericanAirlinesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace AmericanAirlinesApi.Controllers
{
    [ApiController]
    [Route("api/aeronaves")]
    public class AeronaveController : ControllerBase
    {
        
        private readonly AppDbContext _context;
        public AeronaveController(AppDbContext context) => _context = context;
        
        [HttpGet]
        public IActionResult Get()
        {
            var aeronaves = _context.Aeronaves.ToList();
            return Ok(aeronaves);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Aeronave aeronave)
        {
            _context.Aeronaves.Add(aeronave);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = aeronave.Id }, aeronave);
        }

    }
}