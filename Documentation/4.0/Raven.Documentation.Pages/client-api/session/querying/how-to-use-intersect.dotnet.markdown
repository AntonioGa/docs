# Session : Querying : How to Use Intersect

To return only documents that match **all** provided sub-queries, we have introduced the `Intersect` extension which enables us to do server-side intersection queries.

## Syntax

{CODE intersect_1@ClientApi\Session\Querying\HowToUseIntersect.cs /}

## Example

{CODE-TABS}
{CODE-TAB:csharp:Sync intersect_2@ClientApi\Session\Querying\HowToUseIntersect.cs /}
{CODE-TAB:csharp:Async intersect_3@ClientApi\Session\Querying\HowToUseIntersect.cs /}
{CODE-TAB-BLOCK:csharp:RQL}
from index 'TShirts/ByManufacturerColorSizeAndReleaseYear' 
where intersect(Manufacturer = 'Raven', Color = 'Blue' AND Size = 'Small', Color = 'Gray' AND Size = 'Large')
{CODE-TAB-BLOCK/}
{CODE-TABS/}

## Related Articles

- [Indexes : Querying : Intersection](../../../indexes/querying/intersection)
