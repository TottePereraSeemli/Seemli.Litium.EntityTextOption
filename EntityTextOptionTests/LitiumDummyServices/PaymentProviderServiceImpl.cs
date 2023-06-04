using System;
using System.Collections.Generic;
using Litium.Sales;

namespace EntityTextOptionTests.LitiumDummyServices;

internal class PaymentProviderServiceImpl : PaymentProviderService
{
    public override void Create(PaymentProvider paymentProvider)
    {
        throw new NotImplementedException();
    }

    public override void Delete(PaymentProvider paymentProvider)
    {
        throw new NotImplementedException();
    }

    public override PaymentProvider Get(Guid systemId)
    {
        throw new NotImplementedException();
    }

    public override PaymentProvider Get(string id)
    {
        throw new NotImplementedException();
    }

    public override void Update(PaymentProvider paymentProvider)
    {
        throw new NotImplementedException();
    }

    public override IEnumerable<PaymentProvider> GetAll()
    {
        throw new NotImplementedException();
    }

    public override IEnumerable<PaymentProvider> Get(IEnumerable<Guid> systemIds)
    {
        throw new NotImplementedException();
    }
}