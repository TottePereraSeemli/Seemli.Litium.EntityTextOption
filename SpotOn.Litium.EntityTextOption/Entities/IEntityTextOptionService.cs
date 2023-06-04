using Litium.ComponentModel.Internal;
using Litium.FieldFramework.FieldTypes;

namespace SpotOn.Litium.EntityTextOption.Entity;

public interface IEntityTextOptionService
{
    internal List<TextOption.Item> GetEntityItems(Type entityType);
    public T? GetEntity<T>(string value) where T : class, IEntityKey;
    public IEnumerable<T> GetEntities<T>(IEnumerable<string> values) where T : class, IEntityKey;
}