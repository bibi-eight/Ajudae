using Ajudae.Domain.Entities;
using Ajudae.Domain.Enums;

namespace Ajudae.App.ViewModels;

public class VoluntarioViewModel
{
    public Guid Id { get; set; }
    public string NomeCompleto { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public AreaVoluntariadoEnum AreaVoluntariado { get; set; }
    public int Pontuacao { get; set; }
    public int AtividadesFeitas { get; set; }
    public bool Presencial { get; set; }
    public bool Ativo { get; set; }
    public IEnumerable<AtividadeViewModel> Atividades { get; set; }
    public IEnumerable<RecompensaViewModel> Recompensas { get; set; }

    public static VoluntarioViewModel Mapear(Voluntario voluntario)
    {
        return new VoluntarioViewModel()
        {
            Id = voluntario.Id,
            NomeCompleto = voluntario.NomeCompleto,
            Email = voluntario.Email,
            Telefone = voluntario.Telefone,
            AreaVoluntariado = voluntario.AreaVoluntariado,
            Pontuacao = voluntario.Pontuacao,
            AtividadesFeitas = voluntario.AtividadesFeitas,
            Presencial = voluntario.Presencial,
            Ativo = voluntario.Ativo,
            Atividades = voluntario.atividades.Select(AtividadeViewModel.Mapear).ToList(),
            Recompensas = voluntario.recompensas.Select(RecompensaViewModel.Mapear).ToList()
        };
    }
}