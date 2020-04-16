using Microsoft.EntityFrameworkCore;
using Agenda.Data.Models;
using Agenda.Data.Data.Maps;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using System;

namespace Agenda.Data.Data
{
    public class AgendaDataContext : DbContext
    {
        public DbSet<Sala> Salas { get; set; }
        public DbSet<Responsavel> Responsaveis { get; set; }
        public DbSet<Evento> Eventos { get; set; }

        public AgendaDataContext(DbContextOptions<AgendaDataContext> options) : base(options) { }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                    entry.Property("DataAtualizacao").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                    entry.Property("DataAtualizacao").CurrentValue = DateTime.Now;
                }
            }

            return base.SaveChangesAsync();
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new SalaMap());
            builder.ApplyConfiguration(new EventoMap());
            builder.ApplyConfiguration(new ResponsavelMap());

            builder.Entity<Sala>().HasData
            (
                new Sala { Id = 1, Nome = "Sala de Reunião 1", Ativa = true },
                new Sala { Id = 2, Nome = "Sala de Reunião 2", Ativa = true },
                new Sala { Id = 3, Nome = "Sala de Reunião 3", Ativa = true },
                new Sala { Id = 4, Nome = "Sala de Reunião 4", Ativa = false },
                new Sala { Id = 5, Nome = "Sala de Reunião 5", Ativa = true },
                new Sala { Id = 6, Nome = "Auditório 1", Ativa = true },
                new Sala { Id = 7, Nome = "Auditório 2", Ativa = false },
                new Sala { Id = 8, Nome = "Auditório 3", Ativa = true },
                new Sala { Id = 9, Nome = "Sala de Reunião Diretoria", Ativa = true }
            );

            builder.Entity<Responsavel>().HasData(
                new Responsavel { Id = 1, Nome = "Miguel" },
                new Responsavel { Id = 2, Nome = "Rafaela" },
                new Responsavel { Id = 3, Nome = "Pedro" },
                new Responsavel { Id = 4, Nome = "Carlos" },
                new Responsavel { Id = 5, Nome = "Ana" }
            );

            builder.Entity<Evento>().HasData(
                new Evento 
                { 
                    Id = 1, 
                    Nome = "Reunião Mensal", 
                    Descricao = "", 
                    Inicio = DateTime.Now.AddDays(2), 
                    Fim = DateTime.Now.AddDays(2).AddHours(3), 
                    ResponsavelId = 1, 
                    SalaId = 1 
                },
                new Evento 
                { 
                    Id = 2, 
                    Nome = "Reunião Diretoria", 
                    Descricao = "", 
                    Inicio = DateTime.Now.AddHours(4), 
                    Fim = DateTime.Now.AddHours(5), 
                    ResponsavelId = 2, 
                    SalaId = 9 
                },
                new Evento 
                { 
                    Id = 3, 
                    Nome = "Acompanhamento Projeto", 
                    Descricao = "", 
                    Inicio = DateTime.Now.AddHours(1), 
                    Fim = DateTime.Now.AddDays(3), 
                    ResponsavelId = 3, 
                    SalaId = 5
                }
            );
        }

    }
}