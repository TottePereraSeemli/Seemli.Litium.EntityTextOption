using System;
using System.Collections.Generic;
using Litium.Sales;

namespace EntityTextOptionTests.LitiumDummyServices;

internal class ShippingProviderServiceImpl : ShippingProviderService
{
    public override ShippingProvider Get(Guid systemId)
    {
        throw new NotImplementedException();
    }

    public override ShippingProvider Get(string shippingProviderId)
    {
        throw new NotImplementedException();
    }

    public override void Create(ShippingProvider shippingProvider)
    {
        throw new NotImplementedException();
    }

    public override void Update(ShippingProvider shippingProvider)
    {
        throw new NotImplementedException();
    }

    public override void Delete(ShippingProvider shippingProvider)
    {
        throw new NotImplementedException();
    }

    public override IEnumerable<ShippingProvider> GetAll()
    {
        throw new NotImplementedException();
    }

    public override IEnumerable<ShippingProvider> Get(IEnumerable<Guid> systemIds)
    {
        throw new NotImplementedException();
    }
}