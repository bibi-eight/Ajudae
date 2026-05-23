using Ajudae.App.Application.Commands.Atividades;
using Ajudae.App.Application.Commands.Voluntarios;
using Ajudae.Domain.Interfaces;
using Ajudae.Infra.Repositories;
using EstartandoDevsCore.Mediator;
using FluentValidation.Results;
using MediatR;

namespace Ajudae.App.Configuration;

public static class DependencyInjection
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IMediatorHandler, MediatorHandler>();

        services.AddScoped<IVoluntarioRepository, VoluntarioRepository>();
        services.AddScoped<IAtividadeRepository, AtividadeRepository>();
        
        services.AddScoped<IRequestHandler<AdicionarAtividadeCommand, ValidationResult>, AtividadeCommandHandler>();
        services.AddScoped<IRequestHandler<EditarAtividadeCommand, ValidationResult>, AtividadeCommandHandler>();
        
        services.AddScoped<IRequestHandler<AdicionarVoluntarioCommand, ValidationResult>, VoluntarioCommandHandler>();
        services.AddScoped<IRequestHandler<EditarVoluntarioCommand, ValidationResult>, VoluntarioCommandHandler>();
    }
}