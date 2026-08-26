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
    public ModeloDeTrabalhoEnum ModeloDeTrabalho { get; set; }
    public bool Ativo { get; set; }
    public ICollection<AtividadeVoluntario> atividades { get; set; }
    public ICollection<Recompensa> recompensas { get; set; }

    public Voluntario()
    {
        atividades = new List<AtividadeVoluntario>();
        recompensas = new List<Recompensa>();
    }

    public Voluntario(string nomeCompleto, string email, string telefone, AreaVoluntariadoEnum areaVoluntariado, ModeloDeTrabalhoEnum modelo)
    {
        NomeCompleto = nomeCompleto;
        Email = email;
        Telefone = telefone;
        AreaVoluntariado = areaVoluntariado;
        ModeloDeTrabalho = modelo;
    }
    
    public void AtribuirNomeCompleto(string nomeCompleto) => NomeCompleto = nomeCompleto;
    public void AtribuirEmail(string email) => Email = email;
    public void AtribuirTelefone(string telefone) => Telefone = telefone;
    public void AtribuirAreaVoluntariado(AreaVoluntariadoEnum areaVoluntariado) => AreaVoluntariado = areaVoluntariado;
    public void AtribuirPontuacao(int pontos) => Pontuacao = pontos;
    public void AtribuirModeloDeTrabalho(ModeloDeTrabalhoEnum modeloDeTrabalho) => ModeloDeTrabalho = modeloDeTrabalho;
    public void AtivarVoluntario() => Ativo = true;
    public void DesativarVoluntario() => Ativo = false;

    public void AdicionarAtividade(AtividadeVoluntario atividade)
    {
        atividades.Add(atividade);
        
        atividade.AtribuirStatus(StatusEnum.Pendente);
    }
    
    public void RemoverAtividade(AtividadeVoluntario atividade)
    {
        atividades.Remove(atividade);
        
        atividade.AtribuirStatus(StatusEnum.Nova);
    }
    public void AdicionarRecompensa(Recompensa recompensa)
    {
        recompensas.Add(recompensa);
    }
}

public class RecompensaItem
{
    public int RecompensaId { get; set; }
    public int VoluntarioId { get; set; }
}