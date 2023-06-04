using Litium.FieldFramework.FieldTypes;
using Litium.Globalization;
using Litium.Products;
using Litium.Sales;
using SpotOn.Litium.EntityTextOption.Entity;

namespace SpotOn.Litium.EntityTextOption.Entities.Implementations;

public class PaymentProviderEntity : IEntity
{
    private readonly PaymentProviderService _paymentProviderService;
    private readonly LanguageService _languageService;

    public PaymentProviderEntity(PaymentProviderService paymentProviderService,
        LanguageService languageService)
    {
        _paymentProviderService = paymentProviderService;
        _languageService = languageService;
    }

    public Type EntityType => typeof(PaymentProvider);

    public List<TextOption.Item> GetEntityItems()
    {
        return _paymentProviderService.GetAll().Select(paymentProvider => new TextOption.Item
        {
            Value = paymentProvider.SystemId.ToString(),
            Name = _languageService.GetAll().ToDictionary(l => l.CultureInfo.Name, _ => paymentProvider.Id)
        }).ToList();
    }

    public T? GetEntity<T>(string value)
    {
        return (T) (object) _paymentProviderService.Get(new Guid(value));
    }
}