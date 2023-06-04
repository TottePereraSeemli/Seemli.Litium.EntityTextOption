using System;
using System.Collections.Generic;
using Litium.Products;

namespace EntityTextOptionTests.LitiumDummyServices;

internal class PriceListServiceImpl : PriceListService
{
    public override void Create(ProductPriceList productPriceList)
    {
        throw new NotImplementedException();
    }

    public override void Create<T>(T priceList)
    {
        throw new NotImplementedException();
    }

    public override void Delete(ProductPriceList productPriceList)
    {
        throw new NotImplementedException();
    }

    public override void Delete<T>(T priceList)
    {
        throw new NotImplementedException();
    }

    public override ProductPriceList Get(Guid systemId, bool includeItems = false)
    {
        throw new NotImplementedException();
    }

    public override void Update<T>(T priceList)
    {
        throw new NotImplementedException();
    }

    public override ProductPriceList Get(Guid systemId)
    {
        throw new NotImplementedException();
    }

    public override ProductPriceList Get(string id)
    {
        throw new NotImplementedException();
    }

    public override T Get<T>(string id)
    {
        throw new NotImplementedException();
    }

    public override IEnumerable<T> Get<T>(IEnumerable<Guid> systemIds)
    {
        throw new NotImplementedException();
    }

    public override IEnumerable<ProductPriceList> GetAll(bool includeItems = false)
    {
        throw new NotImplementedException();
    }

    public override IEnumerable<ProductPriceList> GetAll()
    {
        throw new NotImplementedException();
    }

    public override IEnumerable<T> GetAll<T>()
    {
        throw new NotImplementedException();
    }

    public override void Update(ProductPriceList productPriceList)
    {
        throw new NotImplementedException();
    }

    public override T Get<T>(Guid systemId)
    {
        throw new NotImplementedException();
    }

    public override IEnumerable<PriceList> Get(IEnumerable<Guid> systemIds)
    {
        throw new NotImplementedException();
    }

    public override ProductPriceList Get(string id, bool includeItems = false)
    {
        throw new NotImplementedException();
    }
}