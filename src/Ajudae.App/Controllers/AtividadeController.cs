using Ajudae.App.Application.Commands.Atividades;
using Ajudae.App.Models;
using Ajudae.Domain.Interfaces;
using EstartandoDevsCore.Mediator;
using EstartandoDevsWebApiCore.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Ajudae.App.Controllers;

[Route("ajudae/atividade")]
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
    public async Task<IActionResult> Adicionar(AtividadeCadastroModel model)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        var comando = new AdicionarAtividadeCommand(model.Titulo, model.Descricao, model.Pontos, model.Prazo);
        
        var result = await _mediatorHandler.EnviarComando(comando);
        
        return CustomResponse(result);
    }

    [HttpPut]
    public async Task<IActionResult> Editar(Guid atividadeId, AtividadeEdicaoModel model)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);
        
        var comando = new EditarAtividadeCommand(atividadeId, model.Titulo, model.Descricao, model.Pontos);
        
        var result = _mediatorHandler.EnviarComando(comando);
        
        return CustomResponse(result);
    }

    [HttpPatch("editar-prazo")]
    public async Task<IActionResult> EditarPrazo(Guid atividadeId, AtividadePrazoModel model)
    {
        var atividade = await _atividadeRepository.ObterPorId(atividadeId);

        if (atividade is null)
        {
            AdicionarErro("Atividade não encontrada");
            return CustomResponse();
        }
        
        atividade.AtribuirPrazo(DateTime.Parse(model.Prazo));
        
        await _atividadeRepository.UnitOfWork.Commit();
        
        return CustomResponse(atividade);
    }
    
     [HttpPatch("editar-status")]
     public async Task<IActionResult> EditarStatus(Guid atividadeId, Guid voluntarioId, AtividadeStatusModel model)
     {
         var atividade = await _atividadeRepository.Ob(atividadeId);
    
         if (atividade is null)
         {
             AdicionarErro("Atividade não encontrada");
             return CustomResponse();
         }
         
         atividade.(atividade.Status);
         
         await _atividadeRepository.UnitOfWork.Commit();
         
         return CustomResponse(atividade);
     }
}