using Ajudae.App.Application.Commands.Voluntarios;
using Ajudae.App.Models;
using Ajudae.App.ViewModels;
using Ajudae.Domain.Enums;
using Ajudae.Domain.Interfaces;
using EstartandoDevsCore.Mediator;
using EstartandoDevsWebApiCore.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ajudae.App.Controllers;

[Route("ajudae/voluntario")]
public class VoluntarioController : MainController
{
    private readonly IMediatorHandler _mediator;
    private readonly IVoluntarioRepository _voluntarioRepository;   

    public VoluntarioController(IMediatorHandler mediator, IVoluntarioRepository voluntarioRepository)
    {
        _mediator = mediator;
        _voluntarioRepository = voluntarioRepository;
    }

    [HttpPost]
    public async Task<IActionResult> CadastrarVoluntario(VoluntarioModel voluntarioModel)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        var comando = new AdicionarVoluntarioCommand(voluntarioModel.NomeCompleto, voluntarioModel.Email,
            voluntarioModel.Telefone, voluntarioModel.AreaVoluntariado, voluntarioModel.ModeloDeTrabalho);
        
        var result = await _mediator.EnviarComando(comando);
        
        return CustomResponse(result);

    }

    [HttpPut]
    public async Task<IActionResult> EditarDadosPrincipais(Guid voluntarioId, VoluntarioModel voluntarioModel)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);
        
        var comando = new EditarVoluntarioCommand(voluntarioId, voluntarioModel.NomeCompleto, voluntarioModel.Email,
            voluntarioModel.Telefone);
        
        var result = await _mediator.EnviarComando(comando);
        
        return CustomResponse(result);
    }

    [HttpPatch("{voluntarioId:Guid}/modelo-trabalho")]
    public async Task<IActionResult> EditarModeloDeTrabalho(Guid voluntarioId, ModeloDeTrabalhoModel model)
    {
        var voluntario = await _voluntarioRepository.ObterPorId(voluntarioId);

        if (voluntario is null)
        {
            AdicionarErro("Voluntário não encontrado");
            return CustomResponse();
        }
        
        voluntario.AtribuirModeloDeTrabalho(model.ModeloDeTrabalho);

        await _voluntarioRepository.UnitOfWork.Commit();
        
        return CustomResponse();
    }
    
    [HttpPatch("{voluntarioId}/area-voluntariado")]
    public async Task<IActionResult> EditarAreaVoluntariado(Guid voluntarioId, AreaVoluntariadoModel model)
    {
        var voluntario = await _voluntarioRepository.ObterPorId(voluntarioId);

        if (voluntario is null)
        {
            AdicionarErro("Voluntário não encontrado");
            return CustomResponse();
        }
        
        voluntario.AtribuirAreaVoluntariado(model.AreaVoluntariado);

        await _voluntarioRepository.UnitOfWork.Commit();
        
        return CustomResponse();
    }
    
    [HttpPatch("{voluntarioId}/status")]
    public async Task<IActionResult> EditarStatusVoluntario(Guid voluntarioId, bool ativo)
    {
        var voluntario = await _voluntarioRepository.ObterPorId(voluntarioId);

        if (voluntario is null)
        {
            AdicionarErro("Voluntário não encontrado");
            return CustomResponse();
        }
        
        if(voluntario.Ativo) voluntario.DesativarVoluntario();
            voluntario.AtivarVoluntario();
            
        await _voluntarioRepository.UnitOfWork.Commit();
        
        return CustomResponse();
    }

    [HttpGet]
    public async Task<IActionResult> ObterVoluntarios(bool ativo)
    {
        var voluntarios = await _voluntarioRepository.ObterVoluntarios(ativo);

        if (voluntarios is null)
        {
            AdicionarErro("Nenhum voluntário foi encontrado");
            return CustomResponse();
        }
        
        var result = voluntarios.Select(x => VoluntarioViewModel.Mapear(x));
        
        return CustomResponse(result);
    }
    
    [HttpGet("{voluntarioId:Guid}")]
    public async Task<IActionResult> ObterVoluntario(Guid voluntarioId)
    {
        var voluntario = await _voluntarioRepository.ObterPorId(voluntarioId);

        if (voluntario is null)
        {
            AdicionarErro("Voluntário não encontrado");
            return CustomResponse();
        }

        var result = VoluntarioViewModel.Mapear(voluntario);
        
        return CustomResponse(result);
    }
    
}