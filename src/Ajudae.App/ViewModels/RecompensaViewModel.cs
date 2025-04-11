using Ajudae.Domain.Entities;

namespace Ajudae.App.ViewModels;

public class RecompensaViewModel
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public int ValorPontos { get; set; }

    public static RecompensaViewModel Mapear(Recompensa recompensa)
    {
        return new RecompensaViewModel()
        {
            Id = recompensa.Id,
            Nome = recompensa.Nome,
            ValorPontos = recompensa.ValorPontos
        };
    }
}