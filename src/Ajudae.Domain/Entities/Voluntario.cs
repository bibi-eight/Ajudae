using Ajudae.Domain.Enums;
using EstartandoDevsCore.DomainObjects;

namespace Ajudae.Domain.Entities;

public class Voluntario : Entity, IAggregateRoot
{
    public string NomeCompleto { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public AreaVoluntariadoEnum AreaVoluntariado { get; set; }
    public int Pontuacao { get; set; }
    public int AtividadesFeitas { get; set; }
    public bool Presencial { get; set; }
    public bool Ativo { get; set; }
    public List<Atividade> Atividades { get; set; }
    public List<Recompensa> Recompensas { get; set; }

    public Voluntario() { }

    public Voluntario(string nomeCompleto, string email, string telefone, AreaVoluntariadoEnum areaVoluntariado, bool presencial)
    {
        NomeCompleto = nomeCompleto;
        Email = email;
        Telefone = telefone;
        AreaVoluntariado = areaVoluntariado;
        Presencial = presencial;
    }
}