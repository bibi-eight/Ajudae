using Ajudae.Domain.Enums;
using EstartandoDevsCore.DomainObjects;

namespace Ajudae.Domain.Entities;

public class Atividade : Entity, IAggregateRoot
{
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public int Pontos { get; set; }
    public DateTime Prazo { get; set; }
    public ICollection<Voluntario> voluntarios { get; set; }
    
    public Atividade() { }

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
}