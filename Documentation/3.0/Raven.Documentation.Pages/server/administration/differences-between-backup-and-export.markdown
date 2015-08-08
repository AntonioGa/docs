﻿# Differences between backup and export

There are two ways to extract data from RavenDB database. You can either [backup your database](./backup-and-restore) by `Raven.Backup.exe` tool or
[export it](exporting-and-importing-data) by using `Raven.Smuggler.exe` or the Studio. You need to select the appropriate option which 
will satisfy your requirements. This article describes differences between Backup / Restore and Export / Import options.

- Indexes:
    - Backup contains indexes - definitions and data
    - Export doesn't include index data, indexes will be rebuilt after importing based on exported definitions
   
- Data state:
    - Backup is a snapshot of database data at the point when the backup was started
    - Export includes documents created during the export
   
- Restored database state:
    - Restore requires an empty database (unless we restore from an incremental backup)
    - Import can be run on an existing database
  
- Portability: 
    - Backup / Restore only works on the same architecture / Esent version
    - Import / Export works between different architectures and Esent versions

- Speed: 
    - Backup is usually much faster than an export

{INFO: As an administrator, should I do backups, exports or both to be on the safe site?}
You should perform backups which allow quickly restore from a failure on the same / similar system.
Note that also incremental backups are supported.
{INFO/}



