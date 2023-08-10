using Litium.ComponentModel.Internal;
using Litium.FieldFramework;
using Litium.FieldFramework.FieldTypes;
using Litium.Runtime;
using Seemli.Litium.EntityTextOption.Entity;

namespace Seemli.Litium.EntityTextOption.Entities;

public class EntityTextOptionService : IEntityTextOptionService
{
    private readonly IEnumerable<IEntityTextOption<IEntityKey, IArea>> _entityTextOptions;
    private readonly IEnumerable<IEntity> _entities;

    public EntityTextOptionService(
        IEnumerable<IEntityTextOption<IEntityKey, IArea>> entityTextOptions,
        IEnumerable<IEntity> entities)
    {
        _entityTextOptions = entityTextOptions;
        _entities = entities;
    }

    List<TextOption.Item> IEntityTextOptionService.GetEntityItems(Type entityType)
    {
        return _entities.FirstOrDefault(x => x.EntityType == entityType)?.GetEntityItems() ??
               new List<TextOption.Item>();
    }

    public T? GetEntity<T, TArea>(string fieldId, MultiCultureFieldContainer fieldContainer)
        where T : class, IEntityKey
        where TArea : IArea
    {
        var entityTextOption = GetEntityTextOption<T, TArea>(fieldId);

        if (entityTextOption!.MultiSelect)
            throw new ArgumentException(
                $"EntityTextOption for {typeof(T)} and {typeof(TArea)} for field {fieldId} is not a single select use method GetEntities instead");

        var fieldValue = fieldContainer.GetValue<string>(fieldId);

        return GetEntity<T>(fieldValue);
    }

    private T? GetEntity<T>(string fieldValue) where T : class, IEntityKey
    {
        return _entities.FirstOrDefault(x => x.EntityType == typeof(T))
            ?.GetEntity<T>(fieldValue) ?? default;
    }

    private IEntityTextOption<IEntityKey, IArea>? GetEntityTextOption<T, TArea>(string fieldId)
        where T : class, IEntityKey
    {
        return _entityTextOptions.FirstOrDefault(x => x.EntityType == typeof(T)
                                                      && x.AreaType == typeof(TArea)
                                                      && x.FieldId == fieldId)
               ?? throw new ArgumentException(
                   $"No EntityTextOption found for {typeof(T)} and {typeof(TArea)} for field {fieldId}");
    }

    public IEnumerable<T> GetEntities<T, TArea>(string fieldId, MultiCultureFieldContainer fieldContainer)
        where T : class, IEntityKey
        where TArea : IArea
    {
        var entityTextOption = GetEntityTextOption<T, TArea>(fieldId);

        if (!entityTextOption!.MultiSelect)
            return new List<T> {GetEntity<T, TArea>(fieldId, fieldContainer)!};

        var values = fieldContainer.GetValue<IList<string>>(fieldId);
        return values.Select(x => GetEntity<T>(x)).Where(x => x != null);
    }
}