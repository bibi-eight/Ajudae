using Ajudae.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ajudae.Infra.Mappings;

public class RecompensaMapping : IEntityTypeConfiguration<Recompensa>
{
    public void Configure(EntityTypeBuilder<Recompensa> builder)
    {
        builder.ToTable("Recompensas");
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Nome).IsRequired();
        builder.Property(x => x.ValorPontos).IsRequired();
    }
}