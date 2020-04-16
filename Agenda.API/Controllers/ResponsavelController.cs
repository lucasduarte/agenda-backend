using System.Collections.Generic;
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
    public class ResponsavelController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Responsavel>>> GetAllAsync([FromServices] AgendaDataContext context)
        {
            var responsaveis = await context.Responsaveis.ToListAsync();
            return responsaveis;
        }
    }
}
