using System;
using System.Collections.Generic;
using Litium.Globalization;

namespace EntityTextOptionTests.LitiumDummyServices;

internal class ChannelServiceImpl : ChannelService
{
    public override Channel Get(Guid systemId)
    {
        return new Channel(Guid.Empty);
    }

    public override Channel Get(string id)
    {
        throw new NotImplementedException();
    }

    public override IEnumerable<Channel> Get(IEnumerable<Guid> systemIds)
    {
        throw new NotImplementedException();
    }

    public override void Create(Channel channel)
    {
        throw new NotImplementedException();
    }

    public override void Delete(Channel channel)
    {
        throw new NotImplementedException();
    }

    public override void Update(Channel channel)
    {
        throw new NotImplementedException();
    }

    public override IEnumerable<Channel> GetAll()
    {
        throw new NotImplementedException();
    }
}