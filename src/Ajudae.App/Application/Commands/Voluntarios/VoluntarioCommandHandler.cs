using Ajudae.Domain.Entities;
using Ajudae.Domain.Interfaces;
using EstartandoDevsCore.Messages;
using FluentValidation.Results;
using MediatR;

namespace Ajudae.App.Application.Commands.Voluntarios;

public class VoluntarioCommandHandler : CommandHandler,
    IRequestHandler<AdicionarVoluntarioCommand, ValidationResult>,
    IRequestHandler<EditarVoluntarioCommand, ValidationResult>,
    IDisposable
{
    
    private readonly IVoluntarioRepository _repository;

    public VoluntarioCommandHandler(IVoluntarioRepository repository)
    {
        _repository = repository;
    }

    public async Task<ValidationResult> Handle(AdicionarVoluntarioCommand request, CancellationToken cancellationToken)
    {
        if (!request.EstaValido()) return request.ValidationResult;

        if (await _repository.ExisteVoluntario(request.Email))
        {
            AdicionarErro("Já existe um voluntário cadastrado com esse e-mail");
            return ValidationResult;
        }
        
        var voluntario = new Voluntario(request.NomeCompleto, request.Email, request.Telefone, request.AreaVoluntariado, request.Presencial);
        
        _repository.Adicionar(voluntario);

        await PersistirDados(_repository.UnitOfWork);
        
        return ValidationResult;
    }

    public Task<ValidationResult> Handle(EditarVoluntarioCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}