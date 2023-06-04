using System;
using System.Collections.Generic;
using Litium.Globalization;

namespace EntityTextOptionTests.LitiumDummyServices;

public class DomainNameServiceImpl : DomainNameService
{
    public override DomainName Get(Guid systemId)
    {
        throw new NotImplementedException();
    }

    public override DomainName Get(string id)
    {
        throw new NotImplementedException();
    }

    public override IEnumerable<DomainName> GetAll()
    {
        throw new NotImplementedException();
    }

    public override void Create(DomainName domainName)
    {
        throw new NotImplementedException();
    }

    public override void Delete(DomainName domainName)
    {
        throw new NotImplementedException();
    }

    public override void Update(DomainName domainName)
    {
        throw new NotImplementedException();
    }

    public override IEnumerable<DomainName> Get(IEnumerable<Guid> systemIds)
    {
        throw new NotImplementedException();
    }
}