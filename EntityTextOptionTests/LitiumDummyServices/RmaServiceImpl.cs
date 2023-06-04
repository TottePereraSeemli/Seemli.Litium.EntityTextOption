using System;
using System.Collections.Generic;
using Litium.Sales;

namespace EntityTextOptionTests.LitiumDummyServices;

internal class RmaServiceImpl : RmaService
{
    public override void Create(Rma rma)
    {
        throw new NotImplementedException();
    }

    public override void Update(Rma rma)
    {
        throw new NotImplementedException();
    }

    public override void Delete(Rma rma)
    {
        throw new NotImplementedException();
    }

    public override Rma Get(Guid systemId)
    {
        throw new NotImplementedException();
    }

    public override Rma Get(string rmaId)
    {
        throw new NotImplementedException();
    }

    public override IEnumerable<Rma> Get(IEnumerable<Guid> systemIds)
    {
        throw new NotImplementedException();
    }
}