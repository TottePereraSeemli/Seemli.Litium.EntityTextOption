using Litium.FieldFramework.FieldTypes;
using Litium.Products;
using Seemli.Litium.EntityTextOption.Entity;

namespace Seemli.Litium.EntityTextOption.Entities.Implementations;

public class InventoryEntity : IEntity
{
    private readonly InventoryService _inventoryService;

    public InventoryEntity(InventoryService inventoryService)
    {
        _inventoryService = inventoryService;
    }
    
    public Type EntityType => typeof(Inventory);
    
    public List<TextOption.Item> GetEntityItems()
    {
        var displayTemplates = _inventoryService.GetAll();
        return displayTemplates.Select(inventory => new TextOption.Item
        {
            Value = inventory.SystemId.ToString(),
            Name = GetLocalizations(inventory)
        }).ToList();
    }

    private IDictionary<string, string> GetLocalizations(Inventory inventory)
    {
        return inventory.Localizations.ToDictionary(localization => localization.Key,
            localization => localization.Value.Name);
    }

    public T? GetEntity<T>(string value)
    {
        return (T)(object) _inventoryService.Get(new Guid(value));
    }
}