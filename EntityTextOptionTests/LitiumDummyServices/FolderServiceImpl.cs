using System;
using System.Collections.Generic;
using Litium.Media;

namespace EntityTextOptionTests.LitiumDummyServices;

internal class FolderServiceImpl : FolderService
{
    public override void Create(Folder folder)
    {
        throw new NotImplementedException();
    }

    public override void Delete(Folder folder)
    {
        throw new NotImplementedException();
    }

    public override Folder Get(Guid systemId)
    {
        throw new NotImplementedException();
    }

    public override Folder Get(string id)
    {
        throw new NotImplementedException();
    }

    public override IEnumerable<Folder> Get(IEnumerable<Guid> systemIds)
    {
        throw new NotImplementedException();
    }

    public override IEnumerable<Folder> GetChildFolders(Guid? parentCategorySystemId = null)
    {
        throw new NotImplementedException();
    }

    public override void Update(Folder folder)
    {
        throw new NotImplementedException();
    }
}