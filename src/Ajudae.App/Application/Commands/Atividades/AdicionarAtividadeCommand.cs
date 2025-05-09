using Ajudae.Domain.Enums;
using EstartandoDevsCore.Messages;
using FluentValidation;

namespace Ajudae.App.Application.Commands.Atividades;

public class AdicionarAtividadeCommand : Command
{
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public int Pontos { get; set; }
    public string Prazo { get; set; }

    public AdicionarAtividadeCommand(string titulo, string descricao, int pontos)
    {
        Titulo = titulo;
        Descricao = descricao;
        Pontos = pontos;
    }

    public override bool EstaValido()
    {
        var ValidationResult = new AdicionarAtividadeValidation().Validate(this);
        return ValidationResult.IsValid;
    }

    public class AdicionarAtividadeValidation : AbstractValidator<AdicionarAtividadeCommand>
    {
        public AdicionarAtividadeValidation()
        {
            RuleFor(x => x.Titulo)
                .NotEmpty().WithMessage("O campo Título é obrigatório")
                .NotNull().WithMessage("O campo Título é obrigatório");
            
            RuleFor(x => x.Descricao)
                .NotEmpty().WithMessage("O campo Descrição é obrigatório")
                .NotNull().WithMessage("O campo Descrição é obrigatório");

            RuleFor(x => x.Pontos)
                .NotNull().WithMessage("O campo Pontos é obrigatório.")
                .GreaterThan(0).WithMessage("O campo pontos deve ser maior que zero");
            
            //TODO : fazer teste pra quebrar isso
            RuleFor(x => x.Prazo)
                .Must(data =>
                {
                    if (string.IsNullOrWhiteSpace(data)) return true;
                    return DateTime.TryParse(data, out _);
                })
                .WithMessage("Data em formato inválido.");
        }
    }

}