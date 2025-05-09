using Ajudae.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ajudae.Infra.Mappings;

public class AtividadeMapping : IEntityTypeConfiguration<Atividade>
{
    public void Configure(EntityTypeBuilder<Atividade> builder)
    {
        builder.ToTable("Atividades");
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Titulo).IsRequired();
        builder.Property(x => x.Descricao).IsRequired();
        builder.Property(x => x.Pontos);
        builder.Property(x => x.Prazo);
        
        builder
            .HasMany(v => v.voluntarios)
            .WithOne(av => av.Atividade)
            .HasForeignKey(av => av.AtividadeId);        
    }
}

public class AtividadeVoluntarioMapping : IEntityTypeConfiguration<AtividadeVoluntario>
{
    public void Configure(EntityTypeBuilder<AtividadeVoluntario> builder)
    {
        builder.ToTable("AtividadesVoluntarios");

        builder.HasKey(av => new { av.VoluntarioId, av.AtividadeId });

        builder
            .HasOne(av => av.Voluntario)
            .WithMany(v => v.atividades)
            .HasForeignKey(av => av.VoluntarioId);

        builder
            .HasOne(av => av.Atividade)
            .WithMany(a => a.voluntarios)
            .HasForeignKey(av => av.AtividadeId);

        builder
            .Property(av => av.Status)
            .IsRequired();
    }
}
