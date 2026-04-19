using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmericanAirlinesApi.Data;
using AmericanAirlinesApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AmericanAirlinesApi.Controllers
{
    [ApiController]
    [Route ("api/reserva/[controller]")]
    public class ReservaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ReservaController(AppDbContext context) => _context = context;

        [HttpPost]
        public IActionResult Post(Reserva reserva)
        {
            var capacidadePassageiros = _context.Aeronaves.Where(a => a.Id == reserva.VooId).Select(a => a.CapacidadedePassageiros).FirstOrDefault();
            var numeroReserva = _context.Reservas.Any(a => a.Id == reserva.VooId);
            var valorPassagem = 0m;

           if(capacidadePassageiros == 0)
                return BadRequest("Voo lotado. Não é possível realizar novas reservas.");

            if (reserva.Assento.EndsWith("A") || reserva.Assento.EndsWith("F"))
            {
                valorPassagem += 50m;
                Console.WriteLine(" Assento na janela reservado com sucesso!");
            }


            _context.Reservas.Add(reserva);
            _context.SaveChanges();

            return Ok(reserva);
        }

        
    }
}