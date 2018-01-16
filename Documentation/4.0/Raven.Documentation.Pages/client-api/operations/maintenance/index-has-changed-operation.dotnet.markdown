﻿# Operations : How to check if an index has changed?

**IndexHasChangedOperation** will let you check if the given index definition differs from the one on a server. This might be useful when you want to check the prior index deployment, if index will be overwritten, and if indexing data will be lost.

## Syntax

{CODE index_has_changed_1@ClientApi\Operations\IndexHasChanged.cs /}

| Parameters | | |
| ------------- | ------------- | ----- |
| **indexDef** | [IndexDefinition](../../../glossary/index-definition) | index definition |

| Return Value | |
| ------------- | ----- |
| true | if an index **does not exist** on a server |
| true | if an index definition **does not match** the one from the **indexDef** parameter |
| false | if there are no differences between an index definition on server and the one from the **indexDef** parameter |

## Example

{CODE index_has_changed_2@ClientApi\Operations\IndexHasChanged.cs /}

## Related articles


- [How to **get index**?](../../../client-api/operations/maintenance/get-index-operation)
- [How to **put index**?](../../../client-api/operations/maintenance/put-indexes-operation)
- [How to **delete index**?](../../../client-api/operations/maintenance/delete-index-operation)
