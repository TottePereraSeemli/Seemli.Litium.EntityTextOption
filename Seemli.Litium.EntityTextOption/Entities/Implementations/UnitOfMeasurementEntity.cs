using Litium.FieldFramework.FieldTypes;
using Litium.Products;
using Seemli.Litium.EntityTextOption.Entity;

namespace Seemli.Litium.EntityTextOption.Entities.Implementations;

public class UnitOfMeasurementEntity : IEntity
{
    private readonly UnitOfMeasurementService _unitOfMeasurementService;

    public UnitOfMeasurementEntity(UnitOfMeasurementService unitOfMeasurementService)
    {
        _unitOfMeasurementService = unitOfMeasurementService;
    }

    public Type EntityType => typeof(UnitOfMeasurement);

    public List<TextOption.Item> GetEntityItems()
    {
        return _unitOfMeasurementService.GetAll().Select(unitOfMeasurement => new TextOption.Item
        {
            Value = unitOfMeasurement.SystemId.ToString(),
            Name = GetLocalizations(unitOfMeasurement)
        }).ToList();
    }

    public T? GetEntity<T>(string value)
    {
        return (T) (object) _unitOfMeasurementService.Get(new Guid(value));
    }

    private IDictionary<string, string> GetLocalizations(UnitOfMeasurement unitOfMeasurement)
    {
        return unitOfMeasurement.Localizations.ToDictionary(l => l.Key, l => l.Value.Name);
    }
}