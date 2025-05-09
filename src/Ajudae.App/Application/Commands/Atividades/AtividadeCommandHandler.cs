using Ajudae.Domain.Entities;
using Ajudae.Domain.Enums;
using Ajudae.Domain.Interfaces;
using EstartandoDevsCore.Messages;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Routing.Matching;

namespace Ajudae.App.Application.Commands.Atividades;

public class AtividadeCommandHandler : CommandHandler,
    IRequestHandler<AdicionarAtividadeCommand, ValidationResult>,
    IRequestHandler<EditarAtividadeCommand, ValidationResult>,
    IDisposable
{
    private readonly IAtividadeRepository _atividadeRepository;

    public AtividadeCommandHandler(IAtividadeRepository atividadeRepository)
    {
        _atividadeRepository = atividadeRepository;
    }


    public async Task<ValidationResult> Handle(AdicionarAtividadeCommand request, CancellationToken cancellationToken)
    {
        if (!request.EstaValido()) return request.ValidationResult;
        
        if (await _atividadeRepository.ExisteAtividade(request.Titulo))
        {
            AdicionarErro("Já existe uma atividade cadastrada com esse título");
            return ValidationResult;
        }
        
        var atividade = new Atividade(request.Titulo, request.Descricao, request.Pontos);

        if (!string.IsNullOrEmpty(request.Prazo))
        {
            atividade.AtribuirPrazo(DateTime.Parse(request.Prazo));
        }
        
        _atividadeRepository.Adicionar(atividade);

        await PersistirDados(_atividadeRepository.UnitOfWork);
        
        return ValidationResult;

    }

    public async Task<ValidationResult> Handle(EditarAtividadeCommand request, CancellationToken cancellationToken)
    {
        if (!request.EstaValido()) return request.ValidationResult;

        var atividade = await _atividadeRepository.ObterPorId(request.Id);

        if (atividade == null)
        {
            AdicionarErro("Atividade não encontrada");
            return ValidationResult;
        }
        
        atividade.AtribuirTitulo(request.Titulo);
        atividade.AtribuirDescricao(request.Descricao);
        atividade.AtribuirPontos(request.Pontos);
        
        _atividadeRepository.Atualizar(atividade);
        
        await PersistirDados(_atividadeRepository.UnitOfWork);

        return ValidationResult;
    }

    public void Dispose()
    {
        _atividadeRepository?.Dispose();
    }
}