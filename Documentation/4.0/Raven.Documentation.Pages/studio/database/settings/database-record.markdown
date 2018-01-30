﻿# Database Record
---

{NOTE: }

* The Database Record document contains the database settings and configuration 

* It is always up to date with the latest database state & tasks

* Every node in the cluster has a copy of this document and will perform its tasks accordingly

* The Database Record is Not editable

{NOTE/}

---

{PANEL: The Database Record}

![Figure 1. Database Record](images/database-record-1.png "The Database Record for database 'db1'")

{PANEL/}

{PANEL: The Database Record Fields}

| - | - |
| `DatabaseName` | The database name as defined when created. <br/> See [Create Database](/server/databases/create-new-database/general-flow) |
| `Disabled` | True or false. <br/> Can be modified in [Databases View](/server/databases/databases-list-view#database-actions) |
| `Encrypted` | True or false, defined when the database is created. <br/> See [Create Database - Encrypted](/server/databases/create-new-database/encrypted) |
| `Topology` | The current Database Group Topology. <br/> Can be managed in [Database Group Topology](../../../todo-update-me-later) |
| `Indexes` | The current indexes defined in the database. <br/> Can be managed in [Indexes](../../../todo-update-me-later) |
| `AutoIndexes` | The current auto-indexes defined in the database. <br/> Can be managed in [Auto-Indexes](../../../todo-update-me-later) |
| `Settings` | Server configuration, <br/> As set in the [settings.json file](/server/configuration/configuration-options#json) |
| `Revisions` | Documents revisions configuration. <br/> Can be set in [Document Revisions](../../../todo-update-me-later) |
| `Expiration` | Documents expiration configuration. <br/> Can be set in [Document Expiration](../../../todo-update-me-later) |
| `PeriodicBackups` | Current Backup tasks configured. <br/> Can be managed in [Backup Task](../../../todo-update-me-later) |
| `ExternalReplications` | Current External Replicaton tasks configured. <br/>Can be managed in [External Replication Task](../../../todo-update-me-later) |
| `RavenConnectionStrings` | RavenDB connection strings that are defined for usage with RavenDB ETL tasks and External Replication tasks. <br/> See [RavenDB Connection Strings](../../../todo-update-me-later) |
| `SqlConnectionStrings` | SQL connection strings that are defined for usage with SQL ETL task . <br/> See [SQL Connection Strings](../../../todo-update-me-later) ||
| `RavenEtls` | Current RavenDB ETL tasks configured. <br/> Can be managed in [RavenDB ETL Task](../../../todo-update-me-later) |
| `SqlEtls` | Current SQL ETL tasks configured. <br/> Can be managed in [SQL ETL Task](../../../todo-update-me-later) |
| `Client` | The database Client Configuration. <br/> As set in [Database Client Configuration](../../../todo-update-me-later) |
| `DeletionInProgress` | A list of nodes that are currently in the process of deleting this database |
| `DeletionInProgressChangeVector` | The _change-vector_ that accompanies a _Delete Database_ command. <br/> Relevant only for a node that has come back from a Rehab state after a partition occured, in order to update the other nodes in the database group with database content updates that occured on this node at partition time. |
| `ConflictSolverConfig` | Conflict Resolution configuration. <br/> Can be set in [Conflict Resolution](../../../todo-update-me-later) |
| `Etag` | The _etag_ of the Database Record document. <br/> (Not to be confused with the database _Last Document Etag_ - <br/> See [Database Stats](../../../todo-update-me-later)) |

{NOTE Fields that are Not defined will Not show in this view /}
{PANEL/}
