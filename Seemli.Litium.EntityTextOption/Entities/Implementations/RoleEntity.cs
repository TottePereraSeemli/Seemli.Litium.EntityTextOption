using Litium.Customers;
using Litium.FieldFramework.FieldTypes;
using Seemli.Litium.EntityTextOption.Entity;

namespace Seemli.Litium.EntityTextOption.Entities.Implementations;

public class RoleEntity : IEntity
{
    private readonly RoleService _roleService;

    public RoleEntity(
        RoleService roleService)
    {
        _roleService = roleService;
    }

    public Type EntityType => typeof(Role);

    public List<TextOption.Item> GetEntityItems()
    {
        return _roleService.GetAll().Select(x => new TextOption.Item
        {
            Value = x.SystemId.ToString(),
            Name = GetLocalizations(x)
        }).ToList();
    }

    private IDictionary<string, string> GetLocalizations(Role role)
    {
        return role.Localizations.ToDictionary(localization =>
                localization.Key,
            localization => localization.Value.Name);
    }

    public T? GetEntity<T>(string value)
    {
        return (T) (object) _roleService.Get(new Guid(value));
    }
}