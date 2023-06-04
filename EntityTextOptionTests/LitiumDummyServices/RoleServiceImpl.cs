using System;
using System.Collections.Generic;
using Litium.Customers;

namespace EntityTextOptionTests.LitiumDummyServices;

internal class RoleServiceImpl : RoleService
{
    public override void Create(Role role)
    {
        throw new NotImplementedException();
    }

    public override void Delete(Role role)
    {
        throw new NotImplementedException();
    }

    public override Role Get(Guid systemId)
    {
        throw new NotImplementedException();
    }

    public override Role Get(string id)
    {
        throw new NotImplementedException();
    }

    public override IEnumerable<Role> GetAll()
    {
        throw new NotImplementedException();
    }

    public override void Update(Role role)
    {
        throw new NotImplementedException();
    }

    public override IEnumerable<Role> Get(IEnumerable<Guid> systemIds)
    {
        throw new NotImplementedException();
    }
}