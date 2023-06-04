using System;
using System.Collections.Generic;
using Litium.Products;

namespace EntityTextOptionTests.LitiumDummyServices;

internal class InventoryServiceImpl : InventoryService
{
    public override void Create(Inventory inventory)
    {
        throw new NotImplementedException();
    }

    public override void Delete(Inventory inventory)
    {
        throw new NotImplementedException();
    }

    public override Inventory Get(Guid systemId)
    {
        throw new NotImplementedException();
    }

    public override Inventory Get(string id)
    {
        throw new NotImplementedException();
    }

    public override IEnumerable<Inventory> GetAll()
    {
        throw new NotImplementedException();
    }

    public override void Update(Inventory inventory)
    {
        throw new NotImplementedException();
    }

    public override IEnumerable<Inventory> Get(IEnumerable<Guid> systemIds)
    {
        throw new NotImplementedException();
    }
}