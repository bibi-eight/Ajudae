using EstartandoDevsCore.DomainObjects;

namespace Ajudae.Domain.Entities;

public class Recompensa : Entity
{
    public string Nome { get; set; }
    public int ValorPontos { get; set; }

    public Recompensa() { }

    public Recompensa(string nome, int valorPontos)
    {
        Nome = nome;
        ValorPontos = valorPontos;
    }
}