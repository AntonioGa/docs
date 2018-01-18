﻿using Raven.Client.Documents;
using Raven.Client.Documents.Operations.Indexes;

namespace Raven.Documentation.Samples.ClientApi.Operations.Indexes
{
    public class StartIndex
    {
        private interface IFoo
        {
            /*
            #region start_1
            public StartIndexOperation(string indexName)
            #endregion
            */
        }

        public StartIndex()
        {
            using (var store = new DocumentStore())
            {
                #region start_2
                store.Maintenance.Send(new StartIndexOperation("Orders/Totals"));
                #endregion
            }
        }
    }
}
