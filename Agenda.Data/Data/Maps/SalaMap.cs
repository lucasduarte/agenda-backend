using Agenda.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Agenda.Data.Data.Maps
{
    public class SalaMap : IEntityTypeConfiguration<Sala>
    {
        public void Configure(EntityTypeBuilder<Sala> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.DataCadastro).IsRequired().ValueGeneratedOnAdd();
            builder.Property(p => p.DataAtualizacao).IsRequired().ValueGeneratedOnAddOrUpdate();
            builder.Property(p => p.Nome).IsRequired().HasMaxLength(30);
            builder.Property(p => p.Ativa).IsRequired();
            builder.HasMany(p => p.Eventos).WithOne(p => p.Sala).HasForeignKey(p => p.SalaId).IsRequired();
        }
    }
}