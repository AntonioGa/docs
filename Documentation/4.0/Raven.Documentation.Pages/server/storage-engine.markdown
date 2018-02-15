﻿#Storage Engine - Voron

RavenDB uses in-house managed storage engine called Voron to persist the data (documents, indexes and configuration). It the high performance storage engine
that was designed and optimized to the needs of RavenDB. It uses the following structures underneath that allow to organize the data on persistent storage efficiently:

- B+Tree - variable size key and value
- Fixed Sized B+Tree - `Int64` key and fixed size value (defined at creation time). It allows to take advantage of various optimizations
- Raw Data Section – it allows to store raw data (e.g. documents content) and gives an identifier that allows access the data in O(1) time
- Table – combination of Raw Data Sections with any number of indexes that under the hood are regular or Fixed Size B+Trees

## Transaction Support

Voron is fully transactional storage engine. It uses Write Ahead Journal to guarantee atomicity and durability of writes. All modifications made within a transaction
are written to a journal file (unbuffered I/O, write-through) before they are applied to the main data file.

The Multi Versioning Concurrency Control (MVCC) is implemented with the usage of scratch files. They are temporary files which keep concurrent versions of the data for running transactions.
Each transaction has a snapshot of the database and can operate on that with guarantee that a write transaction won't modify the data it's looking at.

Snapshot isolation for concurrent transactions is provided by Page Translation Tables.

## Single Write Model

Voron supports only single write process (but there can be multiple read processes). Having only a single write transaction simplifies handling of writes.
In order to provide high performance, RavenDB implements transaction merging on top of that what gives us a tremendous performance boost in high load scenarios.

In addition to that Voron has the notion of async transaction commit (with a list of requirements that must happen to be exactly fit in the transaction merging portion in RavenDB),
and the actual transaction lock handoff / early lock released is handled at a higher layer, with a lot more information about the system.

## Memory Mapped File

Voron is based on memory mapped files.

## Requirements

- Disk must handle UNBUFFERED_IO / WRITE_THROUGH properly
- [Windows] [Hotfix](http://support.microsoft.com/kb/2731284) for Windows 7 and Windows Server 2008 R2
- [Posix] File system must support `fsync`

## Limitations

- The key size must be less than 2025 bytes in UTF8


## Related Articles

- [Transaction Support in RavenDB](../client-api/faq/transaction-support)


