using System;
using System.Collections.Generic;
using Litium.Sales;

namespace EntityTextOptionTests.LitiumDummyServices;

internal class CampaignServiceImpl : CampaignService
{
    public override void Create(Campaign campaign)
    {
        throw new NotImplementedException();
    }

    public override void Update(Campaign campaign)
    {
        throw new NotImplementedException();
    }

    public override void Delete(Campaign campaign)
    {
        throw new NotImplementedException();
    }

    public override Campaign Get(Guid systemId)
    {
        throw new NotImplementedException();
    }

    public override Campaign Get(string id)
    {
        throw new NotImplementedException();
    }

    public override IEnumerable<Campaign> Get(IEnumerable<Guid> systemIds)
    {
        throw new NotImplementedException();
    }
}