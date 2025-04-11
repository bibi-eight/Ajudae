using System.ComponentModel.DataAnnotations;

namespace Ajudae.App.Models;

public class RecompensaModel
{
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public string Nome { get; set; }
    
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public int ValorPontos { get; set; }
}