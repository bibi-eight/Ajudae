using Ajudae.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ajudae.Infra.Mappings;

public class VoluntarioMapping : IEntityTypeConfiguration<Voluntario>
{
    public void Configure(EntityTypeBuilder<Voluntario> builder)
    {
        builder.ToTable("Voluntarios");
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.NomeCompleto).IsRequired();
        builder.Property(x => x.Email).IsRequired();
        builder.Property(x => x.Telefone).IsRequired();
        builder.Property(x => x.AreaVoluntariado).IsRequired();
        builder.Property(x => x.Presencial).IsRequired();
        builder.Property(x => x.Ativo).HasDefaultValueSql();
        builder.Property(x => x.Pontuacao);

    }
}