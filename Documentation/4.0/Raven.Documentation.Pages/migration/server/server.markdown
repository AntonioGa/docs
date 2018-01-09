﻿# How to migrate 3.x server to 4.0?

{WARNING:Backward compatibility}

RavenDB 4.0 is a major version upgrade from 3.x. As such, applications using 3.x client DLLs will not be able to work against 4.0 and require updating to the latest RavenDB.Client release before doing the server upgrade.

{WARNING/}

There are a few options to migrate 3.x data to RavenDB 4.0:

- create database from 3.x data
- live import data from a running instance
- restoring 3.x backup

<br />

{PANEL: How to create database from 3.x database or file system data?}

The process of upgrading to RavenDB 4.0 server is as follows:

- Ensure backups of 3.x databases
- Stop existing 3.x server
- Start new RavenDB 4.0 server (4.0 binaries must not be extracted the same directory as 3.x ones)
- Create new database using `New database from v3.x (legacy) data files`:

![Figure 1. Create new database from 3.x data](images/new-db-from-3.x-data.png)

You will see the following dialog:

![Figure 2. Create new database from 3.x data - dialog](images/new-db-from-3.x-data-dialog.png)

Next, you need to provide the migration configuration:

- `Resource type` - whether you are going to import a database of a file system
- `Data directory` - the absolute path to 3.x data directory
- `Data exporter` - the absolute path to `Raven.StorageExporter.exe` - RavenDB 3.5 tool that can be found on [ravendb.net](http://ravendb.net/download) in Tools package, please make sure you use the latest version

The `Advanced` options section allows to:

- specify custom path to journals / logs (use if the migrated resource has `Raven/TransactionJournalsPath` or `Raven/Esent/LogsPath` setting defined),
- indicate that the source data had the compression bundle enabled
- provide encryption key if the source data are encrypted (if you need the new database to be encrypted, please configure it in `Encryption` section)

{NOTE:Files and legacy attachments}

RavenDB 4.0 introduces the notion of [attachments](../client-api/session/attachments/what-are-attachments) that can be bound to documents. 
The files migrated from RavenFS and legacy database attachments will be saved as documents in `@files` collection. Each document will have a single attachment.
The name of the document will be `files/{attachment-name}`, the name of an attachment will remain unchanged.

{NOTE/}

{PANEL/}

{PANEL: How to live import data from a running instance?}

Another option of moving data to RavenDB 4.0 is to import database from running RavenDB 3.x instance. To import data of running database please create a new empty 
database on 4.0 server and go to `Setting -> Import Data -> From another RavenDB Server`

![Figure 2. Migrate data from another, running RavenDB](images/import-database-from-running-instance.png)


{PANEL/}

{PANEL: How to restore an existing 3.x backup?}

If you want to restore a database from 3.x backup to 4.0 server, first you need to restore it manually to running 3.x instance (by [command line](https://ravendb.net/docs/article-page/3.5/Csharp/server/administration/backup-and-restore) or [RavenDB studio](https://ravendb.net/docs/article-page/3.5/csharp/studio/management/backup-restore)).
Next, use `New database from v3.x (legacy) data files` option, described above, and point the just restored data.

{PANEL/}
