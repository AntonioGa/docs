﻿using System;
using System.Collections.Generic;
using System.Linq;
using NodaTime;
using Raven.Client.Documents.Indexes;
using static Raven.Documentation.Samples.Indexes.PeopleUtil;

namespace Raven.Documentation.Samples.Indexes
{
    public class AdditionalSources 
    {

        public class Person
        {
            public string Name { get; set; }
            public uint Age { get; set; }
        }

#region additional_sources_1
        public class PeopleByEmail : AbstractIndexCreationTask<Person>
        {
            public class PeopleByEmailResult
            {
                public string Email { get; set; }
            }

            public PeopleByEmail()
            {
                Map = people => from person in people
                                select new
                                {
                                    _ = CreateField("Email", CalculatePersonEmail(person.Name, person.Age), true, true),
                                };
                AdditionalSources = new Dictionary<string, string>
                {
                    {
                        "PeopleUtil",
                        @"
                        using System;
                        using NodaTime;
                        using static Raven.Documentation.Samples.Indexes.PeopleUtil;
                        namespace Raven.Documentation.Samples.Indexes
                        {
                            public static class PeopleUtil
                            {
                                public static string CalculatePersonEmail(string name, uint age)
                                {
                                    return $""{name}.{Instant.FromDateTimeUtc(DateTime.Now.ToUniversalTime()).ToDateTimeUtc().Year - age}@ayende.com"";
                                }
                            }
                        }"
                    }
                };
            }
        }
#endregion
    }

    public static class PeopleUtil
    {
        public static string CalculatePersonEmail(string name, uint age)
        {
            return $"{name}.{Instant.FromDateTimeUtc(DateTime.Now.ToUniversalTime()).ToDateTimeUtc().Year - age}@ayende.com";
        }
    }
}
