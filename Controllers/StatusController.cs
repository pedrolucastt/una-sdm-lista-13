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
    [Route("api/status/[controller]")]

    public class StatusController : ControllerBase
    {
        private readonly AppDbContext _context;       
        public StatusController(AppDbContext context) => _context = context;

        [HttpPatch("{id}")]

        public IActionResult Patch(int id, [FromBody] string novoStatus)
        {
            var voo = _context.Voos.Find(id);

            if(voo.Status == "Finalizado" || voo.Status == "Cancelado")
            {
                return BadRequest("Não é possível alterar o status de um voo finalizado ou cancelado.");
            }

            voo.Status = novoStatus;
            _context.SaveChanges();
            return Ok("Status do voo atualizado com sucesso.");
        }
        


        

    }
}