using Litium.ComponentModel.Internal;
using Litium.Runtime;
using Microsoft.Extensions.DependencyInjection;
using SpotOn.Litium.EntityTextOption.Entity;

namespace SpotOn.Litium.EntityTextOption.Registrations;

public static class ServiceCollectionRegistration
{
    public static IServiceCollection AddEntityTextOption<T, TArea>(this IServiceCollection services,
        Action<EntityTextOption<IEntityKey, IArea>> opt)
        where T : IEntityKey
        where TArea : IArea
    {
        var config = new EntityTextOption<IEntityKey, IArea>();
        opt.Invoke(config);
        
        if(config.AreaType == null)
            throw new Exception("AreaType is required");
        
        if(config.AreaType != typeof(TArea))
            throw new Exception($"AreaType must be of type {typeof(TArea)}");

        if (config.EntityType == null)
            throw new Exception("EntityType is required");
        
        if(config.EntityType != typeof(T))
            throw new Exception($"EntityType must be of type {typeof(T)}");
        
        services.AddSingleton<IEntityTextOption<IEntityKey, IArea>>(config);
        services.AddSingleton<IEntityTextOptionService, EntityTextOptionService>();
        
        RegisterEntities(services);
        return services;
    }

    private static void RegisterEntities(IServiceCollection services)
    {
        var entities = typeof(IEntity).Assembly.GetTypes()
            .Where(x => x is {IsAbstract: false, IsClass: true} && x.GetInterfaces().Contains(typeof(IEntity)));

        foreach (var entity in entities)
        {
            services.AddSingleton(typeof(IEntity), entity);
        }
    }
}