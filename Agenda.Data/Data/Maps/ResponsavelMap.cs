using Agenda.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agenda.Data.Data.Maps
{
    public class ResponsavelMap : IEntityTypeConfiguration<Responsavel>
    {
        public void Configure(EntityTypeBuilder<Responsavel> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(p => p.DataCadastro).IsRequired().ValueGeneratedOnAdd();
            builder.Property(p => p.DataAtualizacao).IsRequired().ValueGeneratedOnAddOrUpdate();
            builder.Property(p => p.Nome).IsRequired().HasMaxLength(50);
            builder.HasMany(p => p.Eventos).WithOne(p => p.Responsavel).HasForeignKey(p => p.ResponsavelId).IsRequired();
        }
    }
}