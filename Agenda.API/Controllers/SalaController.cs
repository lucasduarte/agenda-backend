using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agenda.API.ViewModels;
using Agenda.Data.Data;
using Agenda.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Agenda.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalaController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sala>>> GetAllAsync([FromServices] AgendaDataContext context, bool somenteAtiva = false)
        {
            var salaContext = context.Salas;

            IQueryable<Sala> query = null;
            if (somenteAtiva)
                query = salaContext.Where(s => s.Ativa == true);
            else
                query = salaContext;

            var salas = await query.AsNoTracking().ToListAsync();
            return salas;
        }
    }
}
