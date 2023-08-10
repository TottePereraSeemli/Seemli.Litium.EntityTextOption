using Litium.FieldFramework.FieldTypes;
using Litium.Products;
using Seemli.Litium.EntityTextOption.Entity;

namespace Seemli.Litium.EntityTextOption.Entities.Implementations;

public class RelationshipTypeEntity : IEntity
{
    private readonly RelationshipTypeService _relationshipTypeService;

    public RelationshipTypeEntity(
        RelationshipTypeService relationshipTypeService)
    {
        _relationshipTypeService = relationshipTypeService;
    }

    public Type EntityType => typeof(RelationshipType);

    public List<TextOption.Item> GetEntityItems()
    {
        return _relationshipTypeService.GetAll().Select(relationshipType => new TextOption.Item
        {
            Value = relationshipType.SystemId.ToString(),
            Name = GetLocalizations(relationshipType)
        }).ToList();
    }

    private IDictionary<string, string> GetLocalizations(RelationshipType relationshipType)
    {
        return relationshipType.Localizations.ToDictionary(localization =>
                localization.Key,
            localization => localization.Value.Name);
    }

    public T? GetEntity<T>(string value)
    {
        return (T) (object) _relationshipTypeService.Get(new Guid(value));
    }
}