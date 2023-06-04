using Litium.FieldFramework.FieldTypes;
using Litium.Globalization;
using SpotOn.Litium.EntityTextOption.Entity;

namespace SpotOn.Litium.EntityTextOption.Entities.Implementations;

public class LanguageEntity : IEntity
{
    private readonly LanguageService _languageService;

    public LanguageEntity(
        LanguageService languageService)
    {
        _languageService = languageService;
    }

    public Type EntityType => typeof(Language);

    public List<TextOption.Item> GetEntityItems()
    {
        return _languageService.GetAll().Select(language => new TextOption.Item
        {
            Value = language.SystemId.ToString(),
            Name = new Dictionary<string, string>
            {
                {language.CultureInfo.Name, language.Id}
            }
        }).ToList();
    }

    public T? GetEntity<T>(string value)
    {
        return (T) (object) _languageService.Get(new Guid(value));
    }
}