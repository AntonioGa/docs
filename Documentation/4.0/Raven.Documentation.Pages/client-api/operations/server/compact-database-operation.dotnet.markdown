﻿# Operations : How to compact database?

To compact database, please use **CompactDatabaseOperation**. You can choose what should be compacted: documents and/or listed indexes.

## Syntax

{CODE compact_1@ClientApi\Operations\Server\Compact.cs /}

{CODE compact_2@ClientApi\Operations\Server\Compact.cs /}

| Parameters | | |
| ------------- | ------------- | ----- |
| **DatabaseName** | string | Name of a database to compact |
| **Documents** | bool | Indicates, if documents should be compacted |
| **Indexes** | string[] | List of index names to compact |

## Example I

{CODE compact_3@ClientApi\Operations\Server\Compact.cs /}


## Example II

{CODE compact_4@ClientApi\Operations\Server\Compact.cs /}


## Remarks

Compacting operation is executed **asynchronously** and during this operation the **database** will be **offline**.

## Related articles

- [How to **create** database?](../../../client-api/operations/server/create-database-operation) 
- [How to get database **statistics**?](../../../client-api/operations/maintenance/get-statistics-operation)
- [How to start **restore** operation?](../../../client-api/operations/maintenance/restore-backup-operation)

