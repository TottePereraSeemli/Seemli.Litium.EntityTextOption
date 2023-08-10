using Litium.Blocks;
using Litium.Data;
using Litium.FieldFramework.FieldTypes;
using Seemli.Litium.EntityTextOption.Entity;

namespace Seemli.Litium.EntityTextOption.Entities.Implementations;

public class BlockEntity : IEntity
{
    private readonly DataService _dataService;
    private readonly BlockService _blockService;

    public BlockEntity(
        DataService dataService,
        BlockService blockService)
    {
        _dataService = dataService;
        _blockService = blockService;
    }
    
    public Type EntityType => typeof(Block);
    
    public List<TextOption.Item> GetEntityItems()
    {
        List<Block> blocks;
        
        using(var query = _dataService.CreateQuery<Block>())
        {
            blocks = query.ToList();
        }
        
        return blocks.Select(block => new TextOption.Item
        {
            Value = block.SystemId.ToString(),
            Name = GetLocalizations(block)
        }).ToList();
    }

    private IDictionary<string, string> GetLocalizations(Block block)
    {
        return block.Localizations.ToDictionary(localization =>
                localization.Key,
            localization => localization.Value.Name
        );
    }

    public T? GetEntity<T>(string value)
    {
        return (T)(object) _blockService.Get(new Guid(value));
    }
}