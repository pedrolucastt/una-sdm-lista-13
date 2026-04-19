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
    [Route ("api/voos")]

    public class VoosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VoosController(AppDbContext context) => _context = context;

        [HttpPost]
        public IActionResult Post(Voo voo)
        {
            var aeronaveExiste = _context.Aeronaves.Any(a => a.Id == voo.AeronaveId);
            var status = _context.Voos.Any(v => v.AeronaveId == voo.AeronaveId && v.Status == "Em Voo");

            if(aeronaveExiste == false)
                return NotFound("Aeronave não existe");

            if(status)
                return Conflict("Aeronave indisponível, encontra-se em trânsito.");

            _context.Voos.Add(voo);
            _context.SaveChanges();
            return Ok(new { message = $"O Voo {voo} foi agendado." });

        }


    }
}