using Ajudae.Domain.Entities;
using Ajudae.Domain.Enums;

namespace Ajudae.App.ViewModels;

public class AtividadeViewModel
{
    public Guid Id { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public int Pontos { get; set; }
    public string Prazo { get; set; }

    public static AtividadeViewModel Mapear(Atividade atividade)
    {
        return new AtividadeViewModel()
        {
            Id = atividade.Id,
            Titulo = atividade.Titulo,
            Descricao = atividade.Descricao,
            Pontos = atividade.Pontos,
            Prazo = atividade.Prazo.ToString(),
        };
    }
}

public class AtividadeVoluntarioViewModel
{
    public int AtividadeId { get; set; }
    public string Titulo { get; set; }
    public StatusEnum Status { get; set; }

    public static AtividadeVoluntarioViewModel Mapear(AtividadeVoluntario a)
    {
        return new AtividadeVoluntarioViewModel()
        {
            AtividadeId = a.AtividadeId,
            Titulo = a.Atividade.Titulo,
            Status = a.Status
        };
    }
}