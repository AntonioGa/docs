﻿using System.Threading.Tasks;
using Raven.Client.Documents;
using Raven.Client.Documents.BulkInsert;
using Raven.Documentation.Samples.Orders;

namespace Raven.Documentation.Samples.ClientApi.BulkInsert
{
    public class BulkInserts
    {
        private interface IFoo
        {
            #region bulk_inserts_1
            BulkInsertOperation BulkInsert(
                string database = null);
            #endregion
        }

        public BulkInserts()
        {
            using (var store = new DocumentStore())
            {
                #region bulk_inserts_4
                using (BulkInsertOperation bulkInsert = store.BulkInsert())
                {
                    for (int i = 0; i < 1000 * 1000; i++)
                    {
                        bulkInsert.Store(new Employee
                        {
                            FirstName = "FirstName #" + i,
                            LastName = "LastName #" + i
                        });
                    }
                }
                #endregion
            }
        }

        public async Task AsyncBulkInserts()
        {
            using (var store = new DocumentStore())
            {
                #region bulk_inserts_5
                using (BulkInsertOperation bulkInsert = store.BulkInsert())
                {
                    for (int i = 0; i < 1000 * 1000; i++)
                    {
                        await bulkInsert.StoreAsync(new Employee
                        {
                            FirstName = "FirstName #" + i,
                            LastName = "LastName #" + i
                        });
                    }
                }
                #endregion
            }
        }
    }
}
