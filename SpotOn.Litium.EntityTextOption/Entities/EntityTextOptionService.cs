using Litium.ComponentModel.Internal;
using Litium.FieldFramework.FieldTypes;
using Microsoft.Extensions.Logging;

namespace SpotOn.Litium.EntityTextOption.Entity;

public class EntityTextOptionService : IEntityTextOptionService
{
    private readonly ILogger<EntityTextOptionService> _logger;
    private readonly IEnumerable<IEntity> _entities;

    public EntityTextOptionService(
        ILogger<EntityTextOptionService> logger,
        IEnumerable<IEntity> entities)
    {
        _logger = logger;
        _entities = entities;
    }
    
    List<TextOption.Item> IEntityTextOptionService.GetEntityItems(Type entityType)
    {
        return _entities.FirstOrDefault(x => x.EntityType == entityType)?.GetEntityItems() ?? new List<TextOption.Item>();
    }

    public T? GetEntity<T>(string value)
        where T : class, IEntityKey
    {
        return _entities.FirstOrDefault(x => x.EntityType == typeof(T))?.GetEntity<T>(value) ?? default;
    }

    public IEnumerable<T> GetEntities<T>(IEnumerable<string> values) where T : class, IEntityKey
    {
        return values.Select(GetEntity<T>).Where(x => x != null);
    }
}