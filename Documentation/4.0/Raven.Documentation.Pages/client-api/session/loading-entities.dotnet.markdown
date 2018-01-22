﻿# Session : Loading Entities

There are various methods with many overloads that allow users to download documents from a database and convert them to entities. This article will cover the following methods:

- [Load](../../client-api/session/loading-entities#load)
- [Load with Includes](../../client-api/session/loading-entities#load-with-includes)
- [Load - multiple entities](../../client-api/session/loading-entities#load---multiple-entities)
- [LoadStartingWith](../../client-api/session/loading-entities#loadstartingwith)
- [Stream](../../client-api/session/loading-entities#stream)
- [IsLoaded](../../client-api/session/loading-entities#isloaded)

{PANEL:Load}

The most basic way to load a single entity is to use one of the `Load` methods.

{CODE loading_entities_1_0@ClientApi\Session\LoadingEntities.cs /}

| Parameters | | |
| ------------- | ------------- | ----- |
| **id** | string or ValueType | Identifier of a document that will be loaded. |

| Return Value | |
| ------------- | ----- |
| TResult | Instance of `TResult` or `null` if a document with a given ID does not exist. |

### Example

{CODE loading_entities_1_1@ClientApi\Session\LoadingEntities.cs /}


{NOTE In 4.x RavenDB, only string identifiers are supported. If you are upgrading from 3.x, this is a major change because in 3.x non-string identifiers are supported. /}

{PANEL/}

{PANEL:Load with Includes}

When there is a 'relationship' between documents, those documents can be loaded in a single request call using the `Include + Load` methods.

{CODE loading_entities_2_0@ClientApi\Session\LoadingEntities.cs /}

| Parameters | | |
| ------------- | ------------- | ----- |
| **path** | string or Expression | Path in documents in which the server should look for 'referenced' documents. |

| Return Value | |
| ------------- | ----- |
| ILoaderWithInclude | The `Include` method by itself does not materialize any requests but returns loader containing methods such as `Load`. |

### Example I

We can use this code to load also an employee which made the order.

{CODE loading_entities_2_1@ClientApi\Session\LoadingEntities.cs /}

### Example II

{CODE loading_entities_2_2@ClientApi\Session\LoadingEntities.cs /}

{PANEL/}

{PANEL:Load - multiple entities}

To load multiple entities at once, use one of the following `Load` overloads.

{CODE loading_entities_3_0@ClientApi\Session\LoadingEntities.cs /}

| Parameters | | |
| ------------- | ------------- | ----- |
| **ids** | IEnumerable<string> | Multiple document identifiers to load |

| Return Value | |
| ------------- | ----- |
| Dictionary<string, TResult> | Instance of Dictionary which maps document identifiers to `TResult` or `null` if a document with given ID does not exist. |

{CODE loading_entities_3_1@ClientApi\Session\LoadingEntities.cs /}

{PANEL/}

{PANEL:LoadStartingWith}

To load multiple entities that contain a common prefix, use the `LoadStartingWith` method from the `Advanced` session operations.

{CODE loading_entities_4_0@ClientApi\Session\LoadingEntities.cs /}

| Parameters | | |
| ------------- | ------------- | ----- |
| **keyPrefix** | string |  prefix for which documents should be returned  |
| **matches** | string | pipe ('&#124;') separated values for which document IDs (after 'keyPrefix') should be matched ('?' any single character, '*' any characters) |
| **start** | int | number of documents that should be skipped  |
| **pageSize** | int | maximum number of documents that will be retrieved |
| **exclude** | string | pipe ('&#124;') separated values for which document IDs (after 'keyPrefix') should **not** be matched ('?' any single character, '*' any characters) |
| **skipAfter** | string | skip document fetching until given ID is found and return documents after that ID (default: `null`) |

| Return Value | |
| ------------- | ----- |
| TResult[] | Array of entities matching given parameters. |
| Stream | Output entities matching given parameters as a stream. |

### Example I

{CODE loading_entities_4_1@ClientApi\Session\LoadingEntities.cs /}

### Example II

{CODE loading_entities_4_2@ClientApi\Session\LoadingEntities.cs /}

{PANEL/}

{PANEL:Stream}

Entities can be streamed from the server using one of the following `Stream` methods from the `Advanced` session operations.

{CODE loading_entities_5_0@ClientApi\Session\LoadingEntities.cs /}

| Parameters | | |
| ------------- | ------------- | ----- |
| **startsWith** | string | prefix for which documents should be streamed (mutually exclusive with 'fromEtag') |
| **matches** | string | pipe ('&#124;') separated values for which document IDs (after 'keyPrefix') should be matched ('?' any single character, '*' any characters) |
| **start** | int | number of documents that should be skipped  |
| **pageSize** | int | maximum number of documents that will be retrieved |
| **skipAfter** | string | skip document fetching until given ID is found and return documents after that ID (default: `null`) |
| streamQueryStats (out parameter) | Information about the streaming query (amount of results, which index was queried, etc.) |

| Return Value | |
| ------------- | ----- |
| IEnumerator<[StreamResult](../../glossary/stream-result)> | Enumerator with entities. |
| streamQueryStats (out parameter) | Information about the streaming query (amount of results, which index was queried, etc.) |


### Example I

Stream documents for an ID prefix
{CODE loading_entities_5_1@ClientApi\Session\LoadingEntities.cs /}

### Example II
Fetch documents for an ID prefix directly into a stream
{CODE loading_entities_5_2@ClientApi\Session\LoadingEntities.cs /}

### Remarks

{INFO Entities loaded using `Stream` will be transient (not attached to session). /}

{PANEL/}

{PANEL:IsLoaded}

To check if entity is attached to a session, e.g. it has been loaded previously, use the `IsLoaded` method from the `Advanced` session operations.

{CODE loading_entities_6_0@ClientApi\Session\LoadingEntities.cs /}

| Parameters | | |
| ------------- | ------------- | ----- |
| **id** | string | Entity ID for which check should be performed. |

| Return Value | |
| ------------- | ----- |
| bool | Indicates if an entity with a given ID is loaded. |

### Example

{CODE loading_entities_6_1@ClientApi\Session\LoadingEntities.cs /}

{PANEL/}

## Related Articles

- [Opening a session](./opening-a-session)  
