﻿#Commands : DeleteAsync

**DeleteAsync** method is used to delete a file.

## Syntax

{CODE delete_1@FileSystem\ClientApi\Commands\Files.cs /}

| Parameters | | |
| ------------- | ------------- | ----- |
| **filename** | string | The name of a file to delete |
| **etag** | Etag | The current file etag, used for concurrency checks (`null` skips check) |

<hr />

| Return Value | |
| ------------- | ------------- |
| **Task** | A task that represents the asynchronous delete operation. |

## Example

{CODE delete_2@FileSystem\ClientApi\Commands\Files.cs /}

{INFO: Delete on server side}
To delete a file RavenFS needs to remove a lot of information related to this file. In order to respond to the user quickly
the file is just renamed and a delete marker is added to its metadata. The actual delete is performed by [a periodic task](../../../server/background-tasks),
which ensures that all requested deletes will be accomplished even in the presence of server restarts in the middle.
{INFO/}