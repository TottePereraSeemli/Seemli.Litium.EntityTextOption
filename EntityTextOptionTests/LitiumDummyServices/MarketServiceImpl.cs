using System;
using System.Collections.Generic;
using Litium.Globalization;

namespace EntityTextOptionTests.LitiumDummyServices;

internal class MarketServiceImpl : MarketService
{
    public override void Create(Market market)
    {
        throw new NotImplementedException();
    }

    public override void Delete(Market market)
    {
        throw new NotImplementedException();
    }

    public override void Update(Market market)
    {
        throw new NotImplementedException();
    }

    public override Market Get(Guid systemId)
    {
        throw new NotImplementedException();
    }

    public override Market Get(string id)
    {
        throw new NotImplementedException();
    }

    public override IEnumerable<Market> Get(IEnumerable<Guid> systemIds)
    {
        throw new NotImplementedException();
    }

    public override IEnumerable<Market> GetAll()
    {
        throw new NotImplementedException();
    }
}