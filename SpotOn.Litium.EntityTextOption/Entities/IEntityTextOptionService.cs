using Litium.ComponentModel.Internal;
using Litium.FieldFramework;
using Litium.FieldFramework.FieldTypes;
using Litium.Runtime;

namespace SpotOn.Litium.EntityTextOption.Entities;

public interface IEntityTextOptionService
{
    internal List<TextOption.Item> GetEntityItems(Type entityType);

    public T? GetEntity<T, TArea>(string fieldId, MultiCultureFieldContainer fieldContainer)
        where T : class, IEntityKey
        where TArea : IArea;

    public IEnumerable<T> GetEntities<T, TArea>(string fieldId, MultiCultureFieldContainer fieldContainer)
        where T : class, IEntityKey
        where TArea : IArea;
}