﻿# Query vs DocumentQuery

You might be wondering why does the RavenDB client offer two ways of querying by exposing `Query` as well as `DocumentQuery` methods and what are
differences between them.

`DocumentQuery` is the lower level API that we use to query RavenDB but it does not support LINQ - the mandatory data access solution in .NET. Therefore we have created `Query` that that is the LINQ endpoint for RavenDB. 

The entire LINQ API is a wrapper of `DocumentQuery` and is built on top on that. 
So when you use `Query` it always is translated to `DocumentQuery` object, which then builds a RQL-syntax query that is sent to the server.
However we still expose `DocumentQuery` in advanced options to allow the users to have the full power of RQL available to them. 

## Immutability

`DocumentQuery` is mutable while `Query` is immutable. It means that you might get different results if you try to *reuse* a query. The usage of `Query` method like in the following example:

{CODE immutable_query@Indexes\Querying\QueryAndLuceneQuery.cs /}

will cause that the queries will be translated into following Lucene-syntax queries:

`query - from Users where startsWith(Name, 'A')`

`ageQuery - from Users where startsWith(Name, 'A') and Age > 21`

`eyeQuery - from Users where startsWith(Name, 'A') and EyeColor = 'blue'`

The similar usage of `DocumentQuery`:

{CODE mutable_lucene_query@Indexes\Querying\QueryAndLuceneQuery.cs /}

`documentQuery - from Users where startsWith(Name, 'A')` (before creating `ageQuery`)

`ageLuceneQuery - from Users where startsWith(Name, 'A') and Age > 21` (before creating `eyeDocumentQuery`)

`eyeLuceneQuery - from Users where startsWith(Name, 'A') and Age > 21 and EyeColor = 'blue'`

In result all created Lucene queries are the same query (actually the same instance). This is important hint that you should be aware if you are going to reuse `DocumentQuery`.

## Default query operator

Starting from version 4.0, the `Query` and `DocumentQuery` have identical default operator `AND` (previosuly `Query` used `AND` and `DocumentQuery` used `OR`). You are able to change this behavior by using `UsingDefaultOperator`:

{CODE default_operator@Indexes\Querying\QueryAndLuceneQuery.cs /}

## Related articles

- [Querying : Basics](../../indexes/querying/basics)
- [Client API : Session : How to query?](../../client-api/session/querying/how-to-query)
- [Client API : Session : How to use lucene in queries?](../../client-api/session/querying/lucene/how-to-use-lucene-in-queries)
