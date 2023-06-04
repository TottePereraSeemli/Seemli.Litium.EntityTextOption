using System;
using System.Collections.Generic;
using Litium.Blocks;

namespace EntityTextOptionTests.LitiumDummyServices;

internal class BlockServiceImpl : BlockService 
{
    public override Block Get(Guid systemId)
    {
        throw new NotImplementedException();
    }

    public override Block Get(string id)
    {
        throw new NotImplementedException();
    }

    public override IEnumerable<Block> Get(IEnumerable<Guid> systemIds)
    {
        throw new NotImplementedException();
    }

    public override void Create(Block block)
    {
        throw new NotImplementedException();
    }

    public override void Delete(Block block)
    {
        throw new NotImplementedException();
    }

    public override void Unpublish(Block block)
    {
        throw new NotImplementedException();
    }

    public override void Update(Block block)
    {
        throw new NotImplementedException();
    }

    public override void Unpublish(BlockPublishingArgs publishingArgs)
    {
        throw new NotImplementedException();
    }
}