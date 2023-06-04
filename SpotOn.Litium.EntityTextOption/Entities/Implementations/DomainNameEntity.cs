using Litium.FieldFramework.FieldTypes;
using Litium.Globalization;
using SpotOn.Litium.EntityTextOption.Entity;

namespace SpotOn.Litium.EntityTextOption.Entities.Implementations;

public class DomainNameEntity : IEntity
{
    private readonly LanguageService _languageService;
    private readonly DomainNameService _domainNameService;

    public DomainNameEntity(
        LanguageService languageService,
        DomainNameService domainNameService)
    {
        _languageService = languageService;
        _domainNameService = domainNameService;
    }
    
    public Type EntityType => typeof(DomainName);
    public List<TextOption.Item> GetEntityItems()
    {
        return _domainNameService.GetAll().Select(domainName => new TextOption.Item
        {
            Value = domainName.SystemId.ToString(),
            Name = GetLocalizations(domainName)
        }).ToList();
    }

    private IDictionary<string, string> GetLocalizations(DomainName domainName)
    {
        return _languageService.GetAll().ToDictionary(language => language.CultureInfo.Name,
            _ => domainName.Id);
    }

    public T? GetEntity<T>(string value)
    {
        return (T) (object) _domainNameService.Get(new Guid(value));
    }
}