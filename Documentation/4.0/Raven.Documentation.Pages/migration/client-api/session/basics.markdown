﻿# Changes related to IDocumentSession

## Namespace

`IDocumentSession` is can be referenced using `Raven.Client.Documents.Session` (previously `Raven.Client`).

<br />

{PANEL:Load}

### Loading by value type id

Since an entity identifier can be only `string` in RavenDB 4.0 the `Load<T>(ValueType id)` method overload accepting value types (`int`, `Guid` etc.) is no longer available. 
In order to load an entity having value type identifier you need to use a document identifier, that is a collection name concatenated with the value type id.

| 3.x | 4.0 |
|:---:|:---:|
| {CODE load_1_0@Migration\ClientApi\Session\Basics.cs /} | {CODE load_1_1@Migration\ClientApi\Session\Basics.cs /} |

Also `User.Id` property should be `string`.

### Loading multiple documents

The signature of `T[] Load<T>(IEnumerable<string> ids)` method has been changed to `Dictionary<string, T> Load<T>(IEnumerable<string> ids)`. The keys in the returned dictionary are identifiers
of documents requested to be loaded. If a document with was not found then `null` is set in the dictionary under a given id.

| 3.x | 4.0 |
|:---:|:---:|
| {CODE load_2_0@Migration\ClientApi\Session\Basics.cs /} | {CODE load_2_1@Migration\ClientApi\Session\Basics.cs /} |

### Loading with transformer

The `Load` method overloads acceppting transformer name parameter and transformer types as generic have been removed since transformers was completely replaced by projections in RavenDB 4.0.
You need to perform a query and specify a projection instead. The query will be handled very efficiently, directly by a collection storage index, it won't create regular RavenDB index.

| 3.x | 4.0 |
|:---:|:---:|
| {CODE load_3_0@Migration\ClientApi\Session\Basics.cs /} | {CODE load_3_1@Migration\ClientApi\Session\Basics.cs /} |

{PANEL/}

{PANEL:Delete}

### Delete by value type id 

Also the `Delete` method no longer have the following overload `Delete<T>(ValueType id)`. Please pass entity instance that you want to delete or the document identifier including collection name.

| 3.x | 4.0 |
|:---:|:---:|
| {CODE delete_1_0@Migration\ClientApi\Session\Basics.cs /} | {CODE delete_2_0@Migration\ClientApi\Session\Basics.cs /} |

{PANEL/}


