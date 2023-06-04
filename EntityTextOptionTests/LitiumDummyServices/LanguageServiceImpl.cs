using System;
using System.Collections.Generic;
using System.Globalization;
using Litium.Globalization;

namespace EntityTextOptionTests.LitiumDummyServices;

internal class LanguageServiceImpl : LanguageService
{
    public override void Create(Language language)
    {
        throw new NotImplementedException();
    }

    public override void Delete(Language language)
    {
        throw new NotImplementedException();
    }

    public override Language Get(string id)
    {
        throw new NotImplementedException();
    }

    public override IEnumerable<Language> Get(IEnumerable<Guid> systemIds)
    {
        throw new NotImplementedException();
    }

    public override Language Get(CultureInfo culture)
    {
        throw new NotImplementedException();
    }

    public override IEnumerable<Language> GetAll()
    {
        throw new NotImplementedException();
    }

    public override Language GetDefault()
    {
        throw new NotImplementedException();
    }

    public override void Update(Language language)
    {
        throw new NotImplementedException();
    }

    public override Language Get(Guid systemId)
    {
        throw new NotImplementedException();
    }
}