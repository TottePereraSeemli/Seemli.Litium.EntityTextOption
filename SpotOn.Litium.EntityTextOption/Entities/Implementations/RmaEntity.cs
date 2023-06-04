using Litium.Data;
using Litium.FieldFramework.FieldTypes;
using Litium.Globalization;
using Litium.Sales;
using SpotOn.Litium.EntityTextOption.Entity;

namespace SpotOn.Litium.EntityTextOption.Entities.Implementations;

public class RmaEntity : IEntity
{
    private readonly RmaService _rmaService;
    private readonly DataService _dataService;
    private readonly LanguageService _languageService;

    public RmaEntity(RmaService rmaService,
        DataService dataService,
        LanguageService languageService)
    {
        _rmaService = rmaService;
        _dataService = dataService;
        _languageService = languageService;
    }

    public Type EntityType => typeof(Rma);

    public List<TextOption.Item> GetEntityItems()
    {
        List<Rma> rmas;

        using (var query = _dataService.CreateQuery<Rma>())
        {
            rmas = query.ToList();
        }

        return rmas.Select(rma => new TextOption.Item
        {
            Value = rma.SystemId.ToString(),
            Name = _languageService.GetAll().ToDictionary(l => l.CultureInfo.Name, _ => rma.Id)
        }).ToList();
    }

    public T? GetEntity<T>(string value)
    {
        return (T) (object) _rmaService.Get(new Guid(value));
    }
}