using Litium.Data;
using Litium.FieldFramework.FieldTypes;
using Litium.Sales;
using SpotOn.Litium.EntityTextOption.Entity;

namespace SpotOn.Litium.EntityTextOption.Entities.Implementations;

public class DiscountEntity : IEntity
{
    private readonly DiscountService _discountService;
    private readonly DataService _dataService;

    public DiscountEntity(DiscountService discountService,
        DataService dataService)
    {
        _discountService = discountService;
        _dataService = dataService;
    }

    public Type EntityType => typeof(Discount);

    public List<TextOption.Item> GetEntityItems()
    {
        List<Discount> discounts;
        
        using (var query = _dataService.CreateQuery<Discount>())
        {
            discounts = query.ToList();
        }

        return discounts.Select(discount => new TextOption.Item
        {
            Value = discount.SystemId.ToString(),
            Name = GetLocalizations(discount)
        }).ToList();
    }

    public T? GetEntity<T>(string value)
    {
        return (T) (object) _discountService.Get(new Guid(value));
    }

    private IDictionary<string, string> GetLocalizations(Discount discount)
    {
        return discount.Localizations.ToDictionary(l => l.Key, l => l.Value.Name);
    }
}