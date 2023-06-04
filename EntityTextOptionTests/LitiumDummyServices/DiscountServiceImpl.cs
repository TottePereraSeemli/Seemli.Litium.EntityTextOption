using System;
using System.Collections.Generic;
using Litium.Sales;

namespace EntityTextOptionTests.LitiumDummyServices;

internal class DiscountServiceImpl : DiscountService
{
    public override void Create(Discount discount)
    {
        throw new NotImplementedException();
    }

    public override void Update(Discount discount)
    {
        throw new NotImplementedException();
    }

    public override void Delete(Discount discount)
    {
        throw new NotImplementedException();
    }

    public override Discount Get(Guid systemId)
    {
        throw new NotImplementedException();
    }

    public override Discount Get(string id)
    {
        throw new NotImplementedException();
    }

    public override IEnumerable<Discount> Get(IEnumerable<Guid> systemIds)
    {
        throw new NotImplementedException();
    }

    public override Discount<T> Get<T>(string id)
    {
        throw new NotImplementedException();
    }

    public override IEnumerable<Discount> GetByCampaign(Guid campaignSystemId)
    {
        throw new NotImplementedException();
    }

    public override Discount<T> Get<T>(Guid systemId)
    {
        throw new NotImplementedException();
    }
}