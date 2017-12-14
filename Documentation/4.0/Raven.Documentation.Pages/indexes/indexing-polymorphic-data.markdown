# Indexing polymorphic data

By default, RavenDB indexes operate only on a specific entity type, or a `Collection`, and it ignores the inheritance hierarchy.

For example, let's assume that we have the following inheritance hierarchy:

![Figure 1: Polymorphic indexes](images/polymorphic_indexes_faq.png)

If we saved a `Cat`, it would have a collection set to "Cats" and if we saved a `Dog`, it would be in collection "Dogs".

If we wanted to index cats by name, we would write:

{CODE-BLOCK:csharp}
from cat in docs.Cats
select new { cat.Name }
{CODE-BLOCK/}

And for dogs:

{CODE-BLOCK:csharp}
from dog in docs.Dogs
select new { dog.Name }
{CODE-BLOCK/}

Although it works, each index would only give us results for the animal it has been defined on. But what if we wanted to query across all animals?

## Multi-map indexes

The easiest way to do this is by writing a multi-map index like this one:

{CODE multi_map_1@Indexes\IndexingPolymorphicData.cs /}

And query it like this:

{CODE-TABS}
{CODE-TAB:csharp:Query multi_map_3@Indexes\IndexingPolymorphicData.cs /}
{CODE-TAB:csharp:DocumentQuery multi_map_2@Indexes\IndexingPolymorphicData.cs /}
{CODE-TAB-BLOCK:csharp:RQL}
from index 'Animals/ByName'
where Name = 'Mitzy'
{CODE-TAB-BLOCK/}
{CODE-TABS/}

## Other ways

Another option would be to modify the way we generate the Collection for subclasses of `Animal`, like this:

{CODE other_ways_1@Indexes\IndexingPolymorphicData.cs /}

Using this method, we can now index on all animals using:

{CODE-BLOCK:csharp}
from animal in docs.Animals
select new { animal.Name }
{CODE-BLOCK/}

But what happens when you don't want to modify the entity name of an entity itself?

You can create a polymorphic index using:

{CODE-BLOCK:csharp}
from animal in docs.WhereEntityIs("Cats", "Dogs")
select new { animal.Name }
{CODE-BLOCK/}

It will generate an index that matches both Cats and Dogs.

## Related articles

- [Indexing : Basics](../indexes/indexing-basics)
- [Indexing related documents](../indexes/indexing-related-documents)
- [Indexing spatial data](../indexes/indexing-spatial-data)
- [Indexing hierarchical data](../indexes/indexing-hierarchical-data)
- [Querying : Basics](../indexes/querying/basics)
