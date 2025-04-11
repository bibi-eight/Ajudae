using Ajudae.Domain.Entities;
using Ajudae.Domain.Enums;

namespace Ajudae.App.ViewModels;

public class AtividadeViewModel
{
    public Guid Id { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public int Pontos { get; set; }
    public StatusEnum Status { get; set; }
    public string Prazo { get; set; }

    public static AtividadeViewModel Mapear(Atividade atividade)
    {
        return new AtividadeViewModel()
        {
            Id = atividade.Id,
            Titulo = atividade.Titulo,
            Descricao = atividade.Descricao,
            Pontos = atividade.Pontos,
            Status = atividade.Status,
            Prazo = atividade.Prazo.ToString(),
        };
    }
}