# Session : Querying : How to customize query?

Following query customization options are available in `IDocumentQueryCustomization` interface:

- [BeforeQueryExecution](../../../client-api/session/querying/how-to-customize-query#beforequeryexecution)
- [CustomSortUsing](../../../client-api/session/querying/how-to-customize-query#customsortusing)
- [NoCaching](../../../client-api/session/querying/how-to-customize-query#nocaching)
- [NoTracking](../../../client-api/session/querying/how-to-customize-query#notracking)
- [RandomOrdering](../../../client-api/session/querying/how-to-customize-query#randomordering)
- [WaitForNonStaleResultsAsOf](../../../client-api/session/querying/how-to-customize-query#waitfornonstaleresultsasof)
- [WaitForNonStaleResults](../../../client-api/session/querying/how-to-customize-query#waitfornonstaleresults)
<!--- [ShowTimings](../../../client-api/session/querying/how-to-customize-query#showtimings) -->

{PANEL:BeforeQueryExecution}

Allows you to modify the index query just before it is executed.

{CODE customize_1_0@ClientApi\Session\Querying\HowToCustomize.cs /}

| Parameters | | |
| ------------- | ------------- | ----- |
| **action** | Action<[IndexQuery](../../../glossary/index-query)> | Action that will modify IndexQuery. |

| Return Value | |
| ------------- | ----- |
| IDocumentQueryCustomization | Returns self for easier method chaining. |

### Example

{CODE customize_1_1@ClientApi\Session\Querying\HowToCustomize.cs /}

{PANEL/}

{PANEL:NoCaching}

By default, queries are cached. To disable query caching use `NoCaching` customization.

{CODE customize_2_0@ClientApi\Session\Querying\HowToCustomize.cs /}

| Return Value | |
| ------------- | ----- |
| IDocumentQueryCustomization | Returns self for easier method chaining. |

### Example

{CODE customize_2_1@ClientApi\Session\Querying\HowToCustomize.cs /}

{PANEL/}

{PANEL:NoTracking}

To disable entity tracking by `Session` use `NoTracking`. Usage of this option will prevent holding query results in memory.

{CODE customize_3_0@ClientApi\Session\Querying\HowToCustomize.cs /}

| Return Value | |
| ------------- | ----- |
| IDocumentQueryCustomization | Returns self for easier method chaining. |

### Example

{CODE customize_3_1@ClientApi\Session\Querying\HowToCustomize.cs /}

{PANEL/}

{PANEL:RandomOrdering}

To order results randomly use `RandomOrdering` method.

{CODE customize_4_0@ClientApi\Session\Querying\HowToCustomize.cs /}

| Parameters | | |
| ------------- | ------------- | ----- |
| **seed** | string | Seed used for ordering. Useful when repeatable random queries are needed. |

| Return Value | |
| ------------- | ----- |
| IDocumentQueryCustomization | Returns self for easier method chaining. |

### Example

{CODE customize_4_1@ClientApi\Session\Querying\HowToCustomize.cs /}

{PANEL/}

<!--{PANEL:ShowTimings}
TODO arek - restore once RavenDB-9587 will be implemented
By default, detailed timings (duration of Lucene search, loading documents, projecting results) in queries are turned off, this is due to small overhead that calculation of such timings produces.

{CODE customize_6_0@ClientApi\Session\Querying\HowToCustomize.cs /}

| Return Value | |
| ------------- | ----- |
| IDocumentQueryCustomization | Returns self for easier method chaining. |

Returned timings:

- Query parsing
- Lucene search
- Loading documents
- Transforming results

### Example

{CODE customize_6_1@ClientApi\Session\Querying\HowToCustomize.cs /}

{PANEL/} -->

{PANEL:WaitForNonStaleResultsAsOf}

Queries can be 'instructed' to wait for non-stale results as of cutoff etag for specified amount of time using `WaitForNonStaleResultsAsOf` method. 
If the query won't be able to return non-stale results within the specified (or default) timeout then `TimeoutException` is thrown.

{CODE customize_9_0@ClientApi\Session\Querying\HowToCustomize.cs /}

| Parameters | | |
| ------------- | ------------- | ----- |
| **cutOffEtag** | long | Minimum etag of last indexed document. If last indexed document etag is greater than this value the results are considered non-stale. |
| **waitTimeout** | TimeSpan | Time to wait for index to return non-stale results. Default: 15 seconds. |

| Return Value | |
| ------------- | ----- |
| IDocumentQueryCustomization | Returns self for easier method chaining. |

{PANEL/}

{PANEL:WaitForNonStaleResults}

{NOTE This methods should be used only for testing purposes and are considered **EXPERT ONLY** /}

Queries can be 'instructed' to wait for non-stale results for specified amount of time using `WaitForNonStaleResults` method. It is not advised to use this method on live production
database since the high load might cause the index never becomes non-stale. The preffered usage is `WaitForNonStaleResultsAsOf` where the cutoff is specified.

{CODE customize_8_0@ClientApi\Session\Querying\HowToCustomize.cs /}

| Parameters | | |
| ------------- | ------------- | ----- |
| **waitTimeout** | TimeSpan | Time to wait for index to return non-stale results. Default: 15 seconds. |

| Return Value | |
| ------------- | ----- |
| IDocumentQueryCustomization | Returns self for easier method chaining. |

### Example

{CODE customize_8_1@ClientApi\Session\Querying\HowToCustomize.cs /}

{PANEL/}
