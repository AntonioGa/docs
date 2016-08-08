﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Raven.Client.Connection;
using Raven.Client.Document;
using Raven.Client.Indexes;

namespace Raven.Documentation.Samples.ClientApi.Session.HowTo
{
    public class Person
    {
        public string Name;
        public int Age;
    }

    public class Person_ByAge : AbstractIndexCreationTask<Person>
    {
        public Person_ByAge()
        {
            Map = persons => from person in persons
                             select new
                             {
                                 Age = person.Age
                             };
        }
    }

    public class DeleteByIndexWithLinq
    {
        private interface IFoo
        {
            #region delete_by_index_LINQ1

            Operation DeleteByIndex<T, TIndexCreator>(Expression<Func<T, bool>> expression)
                where TIndexCreator : AbstractIndexCreationTask, new();

            Operation DeleteByIndex<T>(string indexName, Expression<Func<T, bool>> expression);

            #endregion
        }

        public DeleteByIndexWithLinq()
        {
            using (var store = new DocumentStore())
            {
                store.Initialize();
                
                using (var session = store.OpenSession())
                {
                    #region delete_by_index_LINQ2
                    // delete all the document in Index Person/ByName from the server with the Name Bob
                    var operation1 = session.Advanced.DeleteByIndex<Person>("Person/ByName", x => x.Name == "Bob");
                    operation1.WaitForCompletion();

                    // delete all the document in Index Person/ByAge that have Age > 35 from the server 
                    var operation2 = session.Advanced.DeleteByIndex<Person, Person_ByAge>(x => x.Age < 35);
                    operation2.WaitForCompletion();
                    #endregion
                }
                
            }
        }
    }
}
