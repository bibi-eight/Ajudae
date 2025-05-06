using Ajudae.Domain.Enums;
using EstartandoDevsCore.Messages;
using FluentValidation;

namespace Ajudae.App.Application.Commands.Voluntarios;

public class EditarVoluntarioCommand : Command
{
    public Guid Id { get; set; }
    public string NomeCompleto { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public AreaVoluntariadoEnum AreaVoluntariado { get; set; }
    public bool Presencial { get; set; }
    
    public EditarVoluntarioCommand( Guid id, string nomeCompleto, string email, string telefone, AreaVoluntariadoEnum areaVoluntariado, bool presencial)
    {
        Id = id;
        NomeCompleto = nomeCompleto;
        Email = email;
        Telefone = telefone;
        AreaVoluntariado = areaVoluntariado;
        Presencial = presencial;
    }

    public override bool EstaValido()
    {
        ValidationResult = new EditarVoluntarioValidation().Validate(this);
        return ValidationResult.IsValid;
    }

    public class EditarVoluntarioValidation : AbstractValidator<EditarVoluntarioCommand>
    {
        public EditarVoluntarioValidation()
        {
            RuleFor(x => x.NomeCompleto)
                .NotEmpty().WithMessage("A propriedade nome é obrigatória")
                .NotNull().WithMessage("A propriedade nome é obrigatória");        
            
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("O e-mail é obrigatório.")
                .EmailAddress().WithMessage("O e-mail informado não é válido.");

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