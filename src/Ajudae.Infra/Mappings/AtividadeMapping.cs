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
        builder.Property(x => x.Status).IsRequired();
        builder.Property(x => x.Pontos);
        builder.Property(x => x.Prazo);
        
        builder.HasMany(x => x.voluntarios).WithMany(x => x.atividades);
        
    }
}