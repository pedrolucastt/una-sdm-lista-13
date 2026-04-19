using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmericanAirlinesApi.Data;
using Microsoft.AspNetCore.Mvc;

namespace AmericanAirlinesApi.Controllers
{
    [ApiController]
    [Route("api/radar/proximos-destinos")]
    public class FlightRadarController : ControllerBase
    {
        
        private readonly AppDbContext _context;
        public FlightRadarController(AppDbContext context) => _context =context;

        [HttpGet]
        public IActionResult Get()
        {
            var quantidadeVoosProgramados = _context.Voos.Count(v => v.Status == "Programado");
            var proximosVoos = _context.Voos.Where(v => v.Status == "Programado").Select(v => new { v.CodigoVoo, v.Origem, v.Destino, quantidadeVoosProgramados }).ToList();
            System.Threading.Thread.Sleep(2000);
            return Ok(proximosVoos);
        }




    }
}