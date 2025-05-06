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

    public async Task<ValidationResult> Handle(EditarVoluntarioCommand request, CancellationToken cancellationToken)
    {
        if(!request.EstaValido()) return request.ValidationResult;

        var voluntario = await _repository.ObterPorId(request.Id);

        if (voluntario is null)
        {
            AdicionarErro("Voluntário não encontrado");
            return ValidationResult;
        }
        
        voluntario.AtribuirNomeCompleto(request.NomeCompleto);
        voluntario.AtribuirEmail(request.Email);
        voluntario.AtribuirTelefone(request.Telefone);
        voluntario.AtribuirAreaVoluntariado(request.AreaVoluntariado);

        if(request.Presencial) voluntario.AtivarVoluntario();
        if(!request.Presencial) voluntario.DesativarVoluntario();
        
        _repository.Atualizar(voluntario);
        
        await PersistirDados(_repository.UnitOfWork);
        
        return ValidationResult;
    }

    public void Dispose()
    {
        _repository?.Dispose();
    }
}