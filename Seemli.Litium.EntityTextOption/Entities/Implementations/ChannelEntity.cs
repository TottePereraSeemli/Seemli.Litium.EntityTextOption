using Litium.FieldFramework.FieldTypes;
using Litium.Globalization;
using Seemli.Litium.EntityTextOption.Entity;

namespace Seemli.Litium.EntityTextOption.Entities.Implementations;

public class ChannelEntity : IEntity
{
    private readonly ChannelService _channelService;

    public ChannelEntity(
        ChannelService channelService)
    {
        _channelService = channelService;
    }

    public Type EntityType => typeof(Channel);

    public List<TextOption.Item> GetEntityItems()
    {
        var channels = _channelService.GetAll();

        return channels.Select(channel => new TextOption.Item
        {
            Value = channel.SystemId.ToString(),
            Name = GetLocalizations(channel)
        }).ToList();
    }

    public T? GetEntity<T>(string value)
    {
        return (T)(object) _channelService.Get(new Guid(value));
    }

    private IDictionary<string, string> GetLocalizations(Channel channel)
    {
        return channel.Localizations.ToDictionary(localization => localization.Key,
            localization => localization.Value.Name);
    }
}