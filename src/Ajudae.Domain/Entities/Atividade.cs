using Ajudae.Domain.Enums;
using EstartandoDevsCore.DomainObjects;

namespace Ajudae.Domain.Entities;

public class Atividade : Entity, IAggregateRoot
{
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public int Pontos { get; set; }
    public StatusEnum Status { get; set; }
    public DateTime Prazo { get; set; }

    public Atividade() { }

    public Atividade(string titulo, string descricao, int pontos, StatusEnum status)
    {
        Titulo = titulo;
        Descricao = descricao;
        Pontos = pontos;
        Status = StatusEnum.Pendente;
    }
}