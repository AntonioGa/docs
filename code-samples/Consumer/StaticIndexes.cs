﻿using System.Collections.Generic;
using System.Linq;
using Raven.Abstractions.Indexing;
using Raven.Client.Indexes;

namespace RavenCodeSamples.Consumer
{
	namespace Foo
	{
		#region index_definition
		class IndexDefinition
		{
			/// <summary>
			/// Get or set the name of the index
			/// </summary>
			public string Name { get; set; }

			/// <summary>
			/// Gets or sets the map function
			/// </summary>
			/// <value>The map.</value>
			public string Map { get; set; }

			/// <summary>
			/// Gets or sets the reduce function
			/// </summary>
			/// <value>The reduce.</value>
			public string Reduce { get; set; }

			/// <summary>
			/// Gets or sets the translator function
			/// </summary>
			public string TransformResults { get; set; }

			/// <summary>
			/// Gets or sets the stores options
			/// </summary>
			/// <value>The stores.</value>
			public IDictionary<string, FieldStorage> Stores { get; set; }

			/// <summary>
			/// Gets or sets the indexing options
			/// </summary>
			/// <value>The indexes.</value>
			public IDictionary<string, FieldIndexing> Indexes { get; set; }

			/// <summary>
			/// Gets or sets the sort options.
			/// </summary>
			/// <value>The sort options.</value>
			public IDictionary<string, SortOptions> SortOptions { get; set; }

			/// <summary>
			/// Gets or sets the analyzers options
			/// </summary>
			/// <value>The analyzers.</value>
			public IDictionary<string, string> Analyzers { get; set; }

			/// <summary>
			/// The fields that are queryable in the index
			/// </summary>
			public IList<string> Fields { get; set; }
		}
		#endregion
	}

	public class StaticIndexes : CodeSampleBase
	{
		public void BasicStaticIndexes()
		{
			using (var documentStore = NewDocumentStore())
			{
				using (var session = documentStore.OpenSession())
				{
					#region static_indexes1
					var results = session.Query<BlogPost>("MyBlogPostsIndex").ToArray();
					#endregion
				}

				#region static_indexes2
				// Create an index where we search based on a post title
				documentStore.DatabaseCommands.PutIndex("BlogPosts/ByTitles",
				                                        new IndexDefinitionBuilder<BlogPost>
				                                        	{
				                                        		Map = posts => from post in posts
				                                        		               select new {post.Title}
				                                        	});
				#endregion

				#region static_indexes3
				documentStore.DatabaseCommands.PutIndex("BlogPosts/PostsCountByTag",
				                                        new IndexDefinitionBuilder<BlogPost, BlogTagPostsCount>
				                                        	{
																// The Map function: for each tag of each post, create a new BlogTagPostsCount
																// object with the name of a tag and a count of one.
				                                        		Map = posts => from post in posts
																			   from tag in post.Tags
																			   select new BlogTagPostsCount
				                                        		                      	{
				                                        		                      		Tag = tag,
				                                        		                      		Count = 1
				                                        		                      	},

																// The Reduce function: group all the BlogTagPostsCount objects we got back
																// from the Map function, use the Tag name as the key, and sum up all the
																// counts. Since the Map function gives each tag a Count of 1, when the Reduce
																// function returns we are going to have the correct Count of posts filed under
																// each tag.
				                                        		Reduce = results => from result in results
				                                        		                    group result by result.Tag into g
				                                        		                    select new BlogTagPostsCount
				                                        		                    		{
				                                        		                    			Tag = g.Key,
				                                        		                    			Count = g.Sum(x => x.Count)
				                                        		                    		}
				                                        	});

				#endregion

				#region static_indexes5
				Raven.Client.Indexes.IndexCreation.CreateIndexes(typeof(BlogPosts_PostsCountByTag).Assembly, documentStore);
				#endregion

				using (var session = documentStore.OpenSession())
				{
					#region static_indexes6
					session.Query<BlogTagPostsCount>("BlogPosts/PostsCountByTag")
						.Where(x => x.Tag == "RavenDB")
						.Count();

					// altenratively, if we used an AbstractIndexCreationTask, we could use this version:

					session.Query<BlogTagPostsCount, BlogPosts_PostsCountByTag>()
						.Where(x => x.Tag == "RavenDB")
						.Count();
					#endregion
				}
			}
		}

		#region static_indexes4
		public class BlogPosts_PostsCountByTag : AbstractIndexCreationTask<BlogPost, BlogTagPostsCount>
		{
			// The index name generated by this is going to be BlogPosts/PostsCountByTag
			public BlogPosts_PostsCountByTag()
			{
				Map = posts => from post in posts
							   from tag in post.Tags
							   select new BlogTagPostsCount
							   {
								   Tag = tag,
								   Count = 1
							   };

				Reduce = results => from result in results
									group result by result.Tag
										into g
										select new BlogTagPostsCount
										{
											Tag = g.Key,
											Count = g.Sum(x => x.Count)
										};
			}
		}
		#endregion
	}
}
