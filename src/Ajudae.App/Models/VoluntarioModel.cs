using System.ComponentModel.DataAnnotations;
using Ajudae.Domain.Enums;

namespace Ajudae.App.Models;

public class VoluntarioModel
{
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public string NomeCompleto { get; set; }
    
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public string Telefone { get; set; }
    
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public AreaVoluntariadoEnum AreaVoluntariado { get; set; }
    
    public bool Presencial { get; set; }
    public bool Ativo { get; set; }
}