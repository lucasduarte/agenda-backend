using Agenda.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Agenda.Data.Data.Maps
{
    public class EventoMap : IEntityTypeConfiguration<Evento>
    {
        public void Configure(EntityTypeBuilder<Evento> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(p => p.DataCadastro).IsRequired().ValueGeneratedOnAdd();
            builder.Property(p => p.DataAtualizacao).IsRequired().ValueGeneratedOnAddOrUpdate();
            builder.Property(p => p.Nome).IsRequired().HasMaxLength(30);
            builder.Property(p => p.Descricao).HasMaxLength(200);
            builder.Property(p => p.Inicio).IsRequired();
            builder.Property(p => p.Fim).IsRequired();
        }
    }
}