using System;
using System.Collections.Generic;
using Litium.Globalization;

namespace EntityTextOptionTests.LitiumDummyServices;

internal class TaxClassServiceImpl : TaxClassService
{
    public override TaxClass Get(Guid systemId)
    {
        throw new NotImplementedException();
    }

    public override TaxClass Get(string id)
    {
        throw new NotImplementedException();
    }

    public override IEnumerable<TaxClass> GetAll()
    {
        throw new NotImplementedException();
    }

    public override void Create(TaxClass taxClass)
    {
        throw new NotImplementedException();
    }

    public override void Delete(TaxClass taxClass)
    {
        throw new NotImplementedException();
    }

    public override void Update(TaxClass taxClass)
    {
        throw new NotImplementedException();
    }

    public override IEnumerable<TaxClass> Get(IEnumerable<Guid> systemIds)
    {
        throw new NotImplementedException();
    }
}