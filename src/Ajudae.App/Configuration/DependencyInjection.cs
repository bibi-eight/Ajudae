using EstartandoDevsCore.Mediator;

namespace Ajudae.App.Configuration;

public static class DependencyInjection
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IMediatorHandler, MediatorHandler>();

    }
}