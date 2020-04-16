using System.Collections.Generic;
using System.Threading.Tasks;
using Agenda.API.ViewModels;
using Agenda.Data.Data;
using Agenda.Data.Models;
using Agenda.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Agenda.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        private readonly EventoRepository _eventoRepository;
        
        public EventoController(EventoRepository eventoRepository)
        {
            _eventoRepository = eventoRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Evento>> GetAllAsync()
        {
            var eventos = await _eventoRepository.GetAllAsync();
            return eventos;
        }


        [HttpPost]
        public async Task<ActionResult<Evento>> PostAsync([FromBody] Evento evento)
        {
            if (!ModelState.IsValid)
                return BadRequest(
                    new ResponseViewModel
                    {
                        Success = false,
                        Message = "Erros de validação.",
                        Data = ModelState
                    }
                );

            var retorno = await _eventoRepository.SaveAsync(evento);
            
            if (retorno != null)
                return BadRequest(
                    new ResponseViewModel
                    {
                        Success = false,
                        Message = "Já existe outro evento agendado para a sala no horário solicitado.",
                        Data = retorno
                    }
                );

            return Ok(
                new ResponseViewModel
                    {
                        Success = true,
                        Message = "Registro inserido com sucesso.",
                        Data = evento
                    }
            );

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseViewModel>> PutAsync(
            int id,
            [FromBody] Evento evento
        )
        {
            if (!ModelState.IsValid)
                return BadRequest(
                    new ResponseViewModel
                    {
                        Success = false,
                        Message = "Erros de validação.",
                        Data = ModelState
                    }
                );

            var existing = await _eventoRepository.GetAsync(id);

            if (existing == null)
                return BadRequest(
                    new ResponseViewModel
                    {
                        Success = false,
                        Message = "Registro não localizado.",
                        Data = null
                    }
                );

            existing.Nome = evento.Nome;
            existing.Descricao = evento.Descricao;
            existing.Inicio = evento.Inicio;
            existing.Fim = evento.Fim;
            existing.SalaId = evento.SalaId;
            existing.ResponsavelId = evento.ResponsavelId;

            var retorno = _eventoRepository.UpdateAsync(existing);

            if (retorno.Result != null)
                return BadRequest(
                    new ResponseViewModel
                    {
                        Success = false,
                        Message = "Já existe outro evento agendado para a sala no horário solicitado.",
                        Data = retorno
                    }
                );

            return Ok(
                new ResponseViewModel
                    {
                        Success = true,
                        Message = "Registro atualizado com sucesso.",
                        Data = evento
                    }
            );
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseViewModel>> Delete(int id)
        {
            var evento = await _eventoRepository.GetAsync(id);

            if (evento == null)
                return BadRequest(
                    new ResponseViewModel
                    {
                        Success = false,
                        Message = "Registro não localizado.",
                        Data = null
                    }
                );

            await _eventoRepository.Remove(evento);

            return Ok(
                new ResponseViewModel
                {
                    Success = true,
                    Message = "Registro removido com sucesso.",
                    Data = evento
                }
            );
        }
    }
}
