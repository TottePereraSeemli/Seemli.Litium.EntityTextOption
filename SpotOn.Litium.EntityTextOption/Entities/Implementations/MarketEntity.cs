using Litium.FieldFramework.FieldTypes;
using Litium.Globalization;
using SpotOn.Litium.EntityTextOption.Entity;

namespace SpotOn.Litium.EntityTextOption.Entities.Implementations;

public class MarketEntity : IEntity
{
    private readonly MarketService _marketService;

    public MarketEntity(
        MarketService marketService)
    {
        _marketService = marketService;
    }

    public Type EntityType => typeof(Market);

    public List<TextOption.Item> GetEntityItems()
    {
        return _marketService.GetAll().Select(market => new TextOption.Item
        {
            Value = market.SystemId.ToString(),
            Name = GetLocalizations(market)
        }).ToList();
    }

    public T? GetEntity<T>(string value)
    {
        return (T) (object) _marketService.Get(new Guid(value));
    }

    private IDictionary<string, string> GetLocalizations(Market market)
    {
        return market.Localizations.ToDictionary(l => l.Key, l => l.Value.Name);
    }
}