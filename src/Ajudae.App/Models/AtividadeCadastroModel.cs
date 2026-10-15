using System.ComponentModel.DataAnnotations;
using Ajudae.Domain.Enums;

namespace Ajudae.App.Models;

public class AtividadeCadastroModel
{
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public string Titulo { get; set; }
    
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public string Descricao { get; set; }
    
    [Required(ErrorMessage = "O valor mínimo de pontos é 1")]
    [Range(1, 1000)]    
    public int Pontos { get; set; }
    public string Prazo { get; set; }
}

public class AtividadeEdicaoModel
{
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public string Titulo { get; set; }
    
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public string Descricao { get; set; }
    
    [Required(ErrorMessage = "O valor mínimo de pontos é 1")]
    [Range(1, 1000)]    
    public int Pontos { get; set; }
}

public class AtividadePrazoModel
{
    public string Prazo { get; set; }
}

public class AtividadeStatusModel
{
    public StatusEnum Status { get; set; }
}