using Litium.FieldFramework.FieldTypes;

namespace SpotOn.Litium.EntityTextOption.Entity;

public interface IEntity
{
    public Type EntityType { get; }
    List<TextOption.Item> GetEntityItems();
    T? GetEntity<T>(string value);
}