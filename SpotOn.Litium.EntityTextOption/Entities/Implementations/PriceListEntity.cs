using Litium.FieldFramework.FieldTypes;
using Litium.Globalization;
using Litium.Products;
using SpotOn.Litium.EntityTextOption.Entity;

namespace SpotOn.Litium.EntityTextOption.Entities.Implementations;

public class PriceListEntity : IEntity
{
    private readonly PriceListService _priceListService;

    public PriceListEntity(PriceListService priceListService)
    {
        _priceListService = priceListService;
    }

    public Type EntityType => typeof(PriceList);

    public List<TextOption.Item> GetEntityItems()
    {
        return _priceListService.GetAll().Select(priceList => new TextOption.Item
        {
            Value = priceList.SystemId.ToString(),
            Name = GetLocalizations(priceList)
        }).ToList();
    }

    public T? GetEntity<T>(string value)
    {
        return (T) (object) _priceListService.Get(new Guid(value));
    }

    private IDictionary<string, string> GetLocalizations(PriceList priceList)
    {
        return priceList.Localizations.ToDictionary(l => l.Key, l => l.Value.Name);
    }
}