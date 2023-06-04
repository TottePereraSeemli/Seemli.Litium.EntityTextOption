using System;
using System.Collections.Generic;
using Litium.Globalization;

namespace EntityTextOptionTests.LitiumDummyServices;

internal class CurrencyServiceImpl : CurrencyService
{
    public override void Create(Currency currency)
    {
        throw new NotImplementedException();
    }

    public override void Delete(Currency currency)
    {
        throw new NotImplementedException();
    }

    public override Currency Get(string id)
    {
        throw new NotImplementedException();
    }

    public override IEnumerable<Currency> Get(IEnumerable<Guid> systemIds)
    {
        throw new NotImplementedException();
    }

    public override IEnumerable<Currency> GetAll()
    {
        throw new NotImplementedException();
    }

    public override Currency GetBaseCurrency()
    {
        throw new NotImplementedException();
    }

    public override void Update(Currency currency)
    {
        throw new NotImplementedException();
    }

    public override Currency Get(Guid systemId)
    {
        throw new NotImplementedException();
    }
}