using Litium.Customers;
using Litium.FieldFramework.FieldTypes;
using SpotOn.Litium.EntityTextOption.Entity;

namespace SpotOn.Litium.EntityTextOption.Entities.Implementations;

public class AddressTypeEntity : IEntity
{
    private readonly AddressTypeService _addressTypeService;

    public AddressTypeEntity(AddressTypeService addressTypeService)
    {
        _addressTypeService = addressTypeService;
    }

    public Type EntityType => typeof(AddressType);

    public List<TextOption.Item> GetEntityItems()
    {
        var addressTypes = _addressTypeService.GetAll();
        return addressTypes.Select(addressType => new TextOption.Item
        {
            Value = addressType.SystemId.ToString(),
            Name = GetLocalizations(addressType)
        }).ToList();
    }

    private IDictionary<string, string> GetLocalizations(AddressType addressType)
    {
        return addressType.Localizations.ToDictionary(localization => localization.Key,
            localization => localization.Value.Name);
    }

    public T? GetEntity<T>(string value)
    {
        return (T) (object) _addressTypeService.Get(new Guid(value));
    }
}