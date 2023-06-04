using Litium.FieldFramework.FieldTypes;
using Litium.Globalization;
using SpotOn.Litium.EntityTextOption.Entity;

namespace SpotOn.Litium.EntityTextOption.Entities.Implementations;

public class CurrencyEntity : IEntity
{
    private readonly LanguageService _languageService;
    private readonly CurrencyService _currencyService;

    public CurrencyEntity(
        LanguageService languageService,
        CurrencyService currencyService)
    {
        _languageService = languageService;
        _currencyService = currencyService;
    }

    public Type EntityType => typeof(Currency);

    public List<TextOption.Item> GetEntityItems()
    {
        return _currencyService.GetAll().Select(currency => new TextOption.Item
        {
            Value = currency.SystemId.ToString(),
            Name = GetLocalizations(currency)
        }).ToList();
    }

    private IDictionary<string, string> GetLocalizations(Currency currency)
    {
        return _languageService.GetAll().ToDictionary(language => language.CultureInfo.Name,
            _ => currency.Id);
    }

    public T? GetEntity<T>(string value)
    {
        return (T) (object) _currencyService.Get(new Guid(value));
    }
}