using Litium.FieldFramework.FieldTypes;
using Litium.Globalization;
using Seemli.Litium.EntityTextOption.Entity;

namespace Seemli.Litium.EntityTextOption.Entities.Implementations;

public class TaxClassEntity : IEntity
{
    private readonly TaxClassService _taxClassService;

    public TaxClassEntity(TaxClassService taxClassService)
    {
        _taxClassService = taxClassService;
    }

    public Type EntityType => typeof(TaxClass);

    public List<TextOption.Item> GetEntityItems()
    {
        return _taxClassService.GetAll().Select(taxClass => new TextOption.Item
        {
            Value = taxClass.SystemId.ToString(),
            Name = GetLocalizations(taxClass)
        }).ToList();
    }

    public T? GetEntity<T>(string value)
    {
        return (T) (object) _taxClassService.Get(new Guid(value));
    }

    private IDictionary<string, string> GetLocalizations(TaxClass taxClass)
    {
        return taxClass.Localizations.ToDictionary(l => l.Key, l => l.Value.Name);
    }
}