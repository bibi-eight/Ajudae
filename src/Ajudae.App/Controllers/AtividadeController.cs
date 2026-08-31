using Ajudae.App.Application.Commands.Atividades;
using Ajudae.App.Models;
using Ajudae.Domain.Interfaces;
using EstartandoDevsCore.Mediator;
using EstartandoDevsWebApiCore.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Ajudae.App.Controllers;

public class AtividadeController : MainController
{
    private readonly IAtividadeRepository _atividadeRepository;
    private readonly IMediatorHandler _mediatorHandler;

    public AtividadeController(IAtividadeRepository atividadeRepository, IMediatorHandler mediatorHandler)
    {
        _atividadeRepository = atividadeRepository;
        _mediatorHandler = mediatorHandler;
    }

    [HttpPost]
    public async Task<IActionResult> Adicionar(AtividadeModel model)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        var comando = new AdicionarAtividadeCommand(model.Titulo, model.Descricao, model.Pontos, model.Prazo);
        
        var result = await _mediatorHandler.EnviarComando(comando);
        
        return CustomResponse(result);
    }

    [HttpPut]
    public async Task<IActionResult> Editar(Guid atividadeId, AtividadeModel model)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);
        
        var comando = new EditarAtividadeCommand(atividadeId, model.Titulo, model.Descricao, model.Pontos);
        
        var result = _mediatorHandler.EnviarComando(comando);
        
        return CustomResponse(result);
    }

    [HttpPatch("editar-status")]
    public async Task<IActionResult> EditarPrazo(Guid atividadeId, AtividadePrazoModel model)
    {
        var atividade = await _atividadeRepository.ObterPorId(atividadeId);

        if (atividade is null)
        {
            AdicionarErro("Atividade não encontrada");
            return CustomResponse();
        }
        
        atividade.AtribuirPrazo(atividade.Prazo);
        
        await _atividadeRepository.UnitOfWork.Commit();
        
        return CustomResponse(atividade);
    }
    
    //TODO:     corrigir endpoint de edição de status obtendo tarefas de outra tabela
    // [HttpPatch("editar-status")]
    // public async Task<IActionResult> EditarStatus(Guid atividadeId, AtividadeStatusModel model)
    // {
    //     var atividade = await _atividadeRepository.ObterPorId(atividadeId);
    //
    //     if (atividade is null)
    //     {
    //         AdicionarErro("Atividade não encontrada");
    //         return CustomResponse();
    //     }
    //     
    //     atividade.(atividade.Status);
    //     
    //     await _atividadeRepository.UnitOfWork.Commit();
    //     
    //     return CustomResponse(atividade);
    // }
}