using Litium.Data;
using Litium.FieldFramework.FieldTypes;
using Litium.Sales;
using Seemli.Litium.EntityTextOption.Entity;

namespace Seemli.Litium.EntityTextOption.Entities.Implementations;

public class CampaignEntity : IEntity
{
    private readonly CampaignService _campaignService;
    private readonly DataService _dataService;

    public CampaignEntity(CampaignService campaignService,
        DataService dataService)
    {
        _campaignService = campaignService;
        _dataService = dataService;
    }

    public Type EntityType => typeof(Campaign);

    public List<TextOption.Item> GetEntityItems()
    {
        List<Campaign> campaigns;

        using (var query = _dataService.CreateQuery<Campaign>())
        {
            campaigns = query.ToList();
        }

        return campaigns.Select(campaign => new TextOption.Item
        {
            Value = campaign.SystemId.ToString(),
            Name = GetLocalizations(campaign)
        }).ToList();
    }

    public T? GetEntity<T>(string value)
    {
        return (T) (object) _campaignService.Get(new Guid(value));
    }

    private IDictionary<string, string> GetLocalizations(Campaign campaign)
    {
        return campaign.Localizations.ToDictionary(l => l.Key, l => l.Value.Name);
    }
}