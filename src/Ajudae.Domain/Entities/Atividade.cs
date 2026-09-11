using Ajudae.Domain.Enums;
using EstartandoDevsCore.DomainObjects;

namespace Ajudae.Domain.Entities;

public class Atividade : Entity, IAggregateRoot
{
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public int Pontos { get; set; }
    public DateTime Prazo { get; set; }
    public ICollection<AtividadeVoluntario> Voluntarios { get; set; } = new List<AtividadeVoluntario>();

    public Atividade()
    {
    }

    public Atividade(string titulo, string descricao, int pontos)
    {
        Titulo = titulo;
        Descricao = descricao;
        Pontos = pontos;
    }

    public void AtribuirTitulo(string titulo) => Titulo = titulo;
    public void AtribuirDescricao(string descricao) => Descricao = descricao;

    public void AtribuirPontos(int pontos) => Pontos = pontos;
    public void AtribuirPrazo(DateTime prazo) => Prazo = prazo;

    public void AdicionarVoluntario(Guid voluntarioId)
    {
        if (Voluntarios.Any(x => x.VoluntarioId == voluntarioId))
            return;

        Voluntarios.Add(new AtividadeVoluntario
        {
            VoluntarioId = voluntarioId,
            AtividadeId = Id,
            Status = StatusEnum.Pendente
        });
    }
}

public class AtividadeVoluntario
{
    public Guid VoluntarioId { get; set; }
    public Voluntario Voluntario { get; set; }

    public Guid AtividadeId { get; set; }
    public Atividade Atividade { get; set; }
    
    public StatusEnum Status { get; set; }
    
    public void AtribuirStatus(StatusEnum status) => Status = status;
}