﻿using System.Linq;
using Raven.Client.Linq;

namespace RavenCodeSamples.Consumer
{
	public class DynamicQueries : CodeSampleBase
	{
		public void LinqQuerying()
		{
			using (var store = NewDocumentStore())
			{
				using (var session = store.OpenSession())
				{
					#region linquerying_1
					var results = (from company in session.Query<Company>()
									   select company)
									   .ToList();
					#endregion
				}

				using (var session = store.OpenSession())
				{
					#region linquerying_2
					// Filtering by string comparison on a property
					var results = from company in session.Query<Company>()
					              where company.Name == "Hibernating Rhinos"
					              select company;

					// Numeric property comparison
					results = from company in session.Query<Company>()
					          where company.NumberOfHappyCustomers > 100
					          select company;

					// Filtering based on a nested property
					results = from company in session.Query<Company>()
					          where company.Employees.Count > 10
					          select company;
					#endregion
				}

				using (var session = store.OpenSession())
				{
					#region linquerying_3
					// Filtering by string comparison on a property
					var results = session.Query<Company>()
						.Where(x => x.Name == "Hibernating Rhinos");

					// Numeric property comparison
					results = session.Query<Company>()
						.Where(x => x.NumberOfHappyCustomers > 100);

					// Filtering based on a nested property
					results = session.Query<Company>()
						.Where(x => x.Employees.Count > 10);
					#endregion
				}

				using (var session = store.OpenSession())
				{
					#region linquerying_4
					// Return only companies having at least one employee named "Ayende"
					IQueryable<Company> companies = from c in session.Query<Company>()
									 where c.Employees.Any(employee => employee.Name == "Ayende")
					                 select c;

					// Returns only companies whose employees hourly rate is less than $30
					companies = from c in session.Query<Company>()
								where c.Employees.All(employee => employee.HourlyRate < 30)
								select c;

					// Query on nested collections - will return any company with at least one developer
					// whose speciality is in C#
					companies = from c in session.Query<Company>()
					            from employee in c.Employees
					            where employee.Specialities.Any(sp => sp == "C#")
					            select c;

					// Using the In operator - return entities whose a field value is in a provided list
					companies = from c in session.Query<Company>()
								where c.Country.In(new [] {"Israel", "USA"})
								select c;
					#endregion
				}

				using (var session = store.OpenSession())
				{
					#region linquerying_5
					// In this sample, we are only interested in the names of the companies satisfying
					// our query conditions, so we project those only into an anonymous object.
					var companyNames = from c in session.Query<Company>()
					                   from employee in c.Employees
					                   where employee.Specialities.Any(sp => sp == "C#")
					                   select new {c.Name}; // This is where the projection happens

					// Same query same idea, but this time we want to get results as objects of type Company.
					// Only the Name property will be populated, the rest will remain empty.
					Company[] companies = (from c in session.Query<Company>()
					                       from employee in c.Employees
					                       where employee.Specialities.Any(sp => sp == "C#")
					                       select new Company {Name = c.Name}) // This is where the projection happens
						.ToArray();
					#endregion
				}
			}
		}
	}
}
