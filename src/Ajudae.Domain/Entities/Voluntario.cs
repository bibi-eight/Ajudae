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
    public ICollection<Atividade> atividades { get; set; }
    public ICollection<RecompensaItem> recompensas { get; set; }

    public Voluntario()
    {
        atividades = new List<Atividade>();
    }

    public Voluntario(string nomeCompleto, string email, string telefone, AreaVoluntariadoEnum areaVoluntariado, bool presencial)
    {
        NomeCompleto = nomeCompleto;
        Email = email;
        Telefone = telefone;
        AreaVoluntariado = areaVoluntariado;
        Presencial = presencial;
    }
    
    public void AtribuirNomeCompleto(string nomeCompleto) => NomeCompleto = nomeCompleto;
    public void AtribuirEmail(string email) => Email = email;
    public void AtribuirTelefone(string telefone) => Telefone = telefone;
    public void AtribuirAreaVoluntariado(AreaVoluntariadoEnum areaVoluntariado) => AreaVoluntariado = areaVoluntariado;
    public void AtribuirPontuacao(int pontos) => Pontuacao = pontos;
    public void TornarPresencial(bool presencial) => Presencial = true;
    public void TornarRemoto(bool presencial) => Presencial = false;
    public void AtivarVoluntario() => Ativo = true;
    public void DesativarVoluntario() => Ativo = false;

    public void AdicionarAtividade(Atividade atividade)
    {
        atividades.Add(atividade);

        if (atividade.Status == StatusEnum.Concluido)
        {
            AtividadesFeitas++;
        }
    }

    public void AdicionarRecompensa(RecompensaItem recompensa)
    {
        recompensas.Add(recompensa);
    }
}

public class RecompensaItem
{
    public int RecompensaId { get; set; }
    public int VoluntarioId { get; set; }
}