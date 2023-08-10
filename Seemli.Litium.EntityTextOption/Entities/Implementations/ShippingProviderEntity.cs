using Litium.FieldFramework.FieldTypes;
using Litium.Globalization;
using Litium.Sales;
using Seemli.Litium.EntityTextOption.Entity;

namespace Seemli.Litium.EntityTextOption.Entities.Implementations;

public class ShippingProviderEntity : IEntity
{
    private readonly ShippingProviderService _shippingProviderService;
    private readonly LanguageService _languageService;

    public ShippingProviderEntity(ShippingProviderService shippingProviderService,
        LanguageService languageService)
    {
        _shippingProviderService = shippingProviderService;
        _languageService = languageService;
    }

    public Type EntityType => typeof(ShippingProvider);

    public List<TextOption.Item> GetEntityItems()
    {
        return _shippingProviderService.GetAll().Select(shippingProvider => new TextOption.Item
        {
            Value = shippingProvider.SystemId.ToString(),
            Name = _languageService.GetAll().ToDictionary(l => l.CultureInfo.Name, _ => shippingProvider.Id)
        }).ToList();
    }

    public T? GetEntity<T>(string value)
    {
        return (T) (object) _shippingProviderService.Get(new Guid(value));
    }
}