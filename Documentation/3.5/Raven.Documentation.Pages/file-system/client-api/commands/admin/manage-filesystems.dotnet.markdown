#Manage file systems

This article will describe the following commands that enable you to manage file systems on a server:    
- [CreateFileSystemAsync ](../../../../file-system/client-api/commands/admin/manage-filesystems#createfilesystemasync)   
- [CreateOrUpdateFileSystemAsync](../../../../file-system/client-api/commands/admin/manage-filesystems#createorupdatefilesystemasync)   
- [EnsureFileSystemExistsAsync ](../../../../file-system/client-api/commands/admin/manage-filesystems#ensurefilesystemexistsasync)    
- [DeleteFileSystemAsync ](../../../../file-system/client-api/commands/admin/manage-filesystems#deletefilesystemasync)  

{PANEL:**CreateFileSystemAsync**}

This method is used to create a new file system. If the file system already exists then it will throw an exception.

## Syntax

{CODE create_fs_1@FileSystem\ClientApi\Commands\Admin.cs /}

| Parameters | | |
| ------------- | ------------- | ----- |
| **filesystemDocument** | [FileSystemDocument](../../../../glossary/file-system-document) |  The document containing all configuration options for a new file system (e.g. active bundles, name/id, data path) |

<hr />

| Return Value | |
| ------------- | ------------- |
| **Task** | A task that represents the asynchronous operation |

## Example

Let's create a new file system with Versioning bundle enabled:

{CODE create_fs_2@FileSystem\ClientApi\Commands\Admin.cs /}

Alternatively, you can use CreateFileSystemDocument() which creates a configuration document with default values:

{CODE create_fs_3@FileSystem\ClientApi\Commands\Admin.cs /}

{PANEL/}


{PANEL:**CreateOrUpdateFileSystemAsync**}

This method creates a new file system or updates the configuration of an already existing one according to the specified document.

{CODE create_or_update_fs_1@FileSystem\ClientApi\Commands\Admin.cs /}

| Parameters | | |
| ------------- | ------------- | ----- |
| **filesystemDocument** | [FileSystemDocument](../../../../glossary/file-system-document) |  The document containing all configuration options for a new file system (e.g. active bundles, name/id, data path) |
| **newFileSystemName** | string | The new file system name, if `null` then current file system name will be used (`store.AsyncFilesCommands.FileSystem`) |

<hr />

| Return Value | |
| ------------- | ------------- |
| **Task** | A task that represents the asynchronous operation |

{PANEL/}

{PANEL:**EnsureFileSystemExistsAsync**}

Instead of calling the `CreateOrUpdateFileSystemAsync` method, you can use this one to make sure that file system exists. If there is no such file system, it will be created with default settings.

{CODE ensure_fs_exists_1@FileSystem\ClientApi\Commands\Admin.cs /}

| Parameters | | |
| ------------- | ------------- | ----- |
| **fileSystem** | string | The file system name |

<hr />

| Return Value | |
| ------------- | ------------- |
| **Task** | A task that represents the asynchronous operation |

## Example

{CODE ensure_fs_exists_2@FileSystem\ClientApi\Commands\Admin.cs /}

{PANEL/}

{PANEL:**DeleteFileSystemAsync**}

This method is used to delete a file system from a server, with a possibility to remove its all data from the hard drive.

{CODE delete_fs_1@FileSystem\ClientApi\Commands\Admin.cs /}

| Parameters | | |
| ------------- | ------------- | ----- |
| **fileSystemName** | string | The name of a file system to delete, if `null` then current file system name will be used (`store.AsyncFilesCommands.FileSystem`) |
| **hardDelete** | bool | Determines if all data should be removed (data files, indexing files, etc.). Default: `false` |

<hr />

| Return Value | |
| ------------- | ------------- |
| **Task** | A task that represents the asynchronous delete operation |

## Example

The below code deletes the current file system together with its data on the hard drive:

{CODE delete_fs_2@FileSystem\ClientApi\Commands\Admin.cs /}

{PANEL/}