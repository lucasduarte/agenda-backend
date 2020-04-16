using System.Collections.Generic;
using System.Threading.Tasks;
using Agenda.Data.Data;
using Agenda.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Agenda.Data.Repositories
{
    public class EventoRepository
    {
        private readonly AgendaDataContext _context;

        public EventoRepository(AgendaDataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Evento>> GetAllAsync()
        {
            var eventos = await _context.Eventos
                .Include(s => s.Sala)
                .Include(r => r.Responsavel)
                .ToListAsync();

            return eventos;
        }

        public async Task<Evento> GetAsync(int id)
        {
            var evento = await _context.Eventos
                .Include(s => s.Sala)
                .Include(r => r.Responsavel)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            return evento;
        }

        public async Task<IEnumerable<Evento>> VerificaEvento(Evento evento)
        {
            var existeEvento = await _context.Eventos.Where(
                x => x.SalaId == evento.SalaId 
                && x.Id != evento.Id
                && (
                    ( x.Inicio >= evento.Inicio && x.Inicio < evento.Fim )
                    ||
                    ( x.Fim >= evento.Inicio && x.Fim <= evento.Fim)
                    ||
                    ( evento.Inicio >= x.Inicio && evento.Inicio <= x.Fim)
                    ||
                    ( evento.Fim >= x.Inicio && evento.Fim <= x.Fim)
                )).ToListAsync();

            return existeEvento;
        }

        public async Task<Evento> SaveAsync(Evento evento)
        {
            var eventos = await VerificaEvento(evento);

            if (eventos.Count() > 0)
                return eventos.First();

            _context.Eventos.Add(evento);
            await _context.SaveChangesAsync();
            return null;
        }

        public async Task<Evento> UpdateAsync(Evento evento)
        {
            var eventos = await VerificaEvento(evento);

            if (eventos.Count() > 0)
                return eventos.First();

            _context.Eventos.Update(evento);
            await _context.SaveChangesAsync();
            return null;
        }

        public async Task<int> Remove(Evento evento)
        {
            _context.Eventos.Remove(evento);
            return await _context.SaveChangesAsync();
        }
    }
}