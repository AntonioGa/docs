# Session : How to Ignore Entity Changes

In order to mark an entity as one that should be ignored for change tracking purposes, use the `IgnoreChangesFor` method from `Advanced` session operations.  
The entity will still take part in the session, but will be ignored for `SaveChanges`.

## Syntax

{CODE ignore_changes_1@ClientApi\Session\HowTo\IgnoreChanges.cs /}

| Parameters | | |
| ------------- | ------------- | ----- |
| **entity** | object | Instance of entity for which changes will be ignored. |


## Example

{CODE ignore_changes_2@ClientApi\Session\HowTo\IgnoreChanges.cs /}
