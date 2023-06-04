using System;
using Litium.Data;
using Litium.Data.Batching;
using Litium.Data.Queryable;

namespace EntityTextOptionTests.LitiumDummyServices;

internal class DataServiceImpl : DataService
{
    public override BatchData CreateBatch(Action<BatchDataOptionsBuilder> options = null)
    {
        throw new NotImplementedException();
    }

    public override QueryBuilder<T> CreateQuery<T>(Action<QueryOptionsBuilder<T>> options = null)
    {
        throw new NotImplementedException();
    }
}