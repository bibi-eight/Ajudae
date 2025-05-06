using Ajudae.Domain.Enums;
using EstartandoDevsCore.Messages;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace Ajudae.App.Application.Commands.Voluntarios;

public class AdicionarVoluntarioCommand : Command
{
    public string NomeCompleto { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public AreaVoluntariadoEnum AreaVoluntariado { get; set; }
    public bool Presencial { get; set; }

    public AdicionarVoluntarioCommand(string nomeCompleto, string email, string telefone, AreaVoluntariadoEnum areaVoluntariado, bool presencial)
    {
        NomeCompleto = nomeCompleto;
        Email = email;
        Telefone = telefone;
        AreaVoluntariado = areaVoluntariado;
        Presencial = presencial;
    }

    public override bool EstaValido()
    {
        ValidationResult = new AdicionarVoluntarioValidation().Validate(this);
        return ValidationResult.IsValid;
    }

    public class AdicionarVoluntarioValidation : AbstractValidator<AdicionarVoluntarioCommand>
    {
        public AdicionarVoluntarioValidation()
        {
            RuleFor(x => x.NomeCompleto)
                .NotEmpty().WithMessage("A propriedade nome é obrigatória")
                .NotNull().WithMessage("A propriedade nome é obrigatória");
            
            //TODO : fazer teste pra quebrar isso
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("O e-mail é obrigatório.")
                .EmailAddress().WithMessage("O e-mail informado não é válido.");
            
            //TODO : fazer teste pra quebrar isso
            RuleFor(x => x.Telefone)
                .NotEmpty().WithMessage("O telefone é obrigatório.")
                .Matches(@"^\(?\d{2}\)?\s?\d{4,5}-?\d{4}$")
                .WithMessage("O telefone informado não é válido.");
                
            RuleFor(x => x.AreaVoluntariado)
                .NotEqual(AreaVoluntariadoEnum.Nenhum)
                .WithMessage("Selecione uma área de voluntariado.");
        }
    }
}