using System.ComponentModel.DataAnnotations;
using Ajudae.Domain.Enums;

namespace Ajudae.App.Models;

public class AtividadeModel
{
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public string Titulo { get; set; }
    
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public string Descricao { get; set; }
    
    [Required(ErrorMessage = "O valor mínimo de pontos é 1")]
    [MinLength(1)]
    public int Pontos { get; set; }
    
    public StatusEnum Status { get; set; }
    public DateTime Prazo { get; set; }
}