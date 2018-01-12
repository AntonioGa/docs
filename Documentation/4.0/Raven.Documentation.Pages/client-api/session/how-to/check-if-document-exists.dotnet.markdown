# Session : How to check if a document exists?

In order to check if a document with specific ID exists in the database, use the `Exists` method from the `Advanced` session operations.

## Syntax

{CODE exists_1@ClientApi\Session\HowTo\Exists.cs /}

| Parameters | | |
| ---------- | ---------- | ----- |
| **id** | string | ID of the document to check the existence of. |

| Return Value | |
| ------------- | ----- |
| bool | Indicates if a document with the given ID exists. |

## Example

{CODE exists_2@ClientApi\Session\HowTo\Exists.cs /}

## Related Articles

- [How to check if there are any changes on a session?](../../../client-api/session/how-to/check-if-there-are-any-changes-on-a-session)
