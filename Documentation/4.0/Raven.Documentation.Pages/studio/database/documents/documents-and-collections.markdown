﻿# Documents and Collections
---

{NOTE: Documents}

* A document holds your data in a JSON format object.  
* For more information about a document see [Document View](../../../../todo-update-me-later)
{NOTE/}

{NOTE: Collections}

* Collections are used to group documents together so that it is convenient to apply some operation to them,  
  i.e. subscribing to changes, indexing, querying, ETL, etc.  

* Every document belongs to exactly one collection.  

* Typically, a collection holds similar structured documents - based on the entity type of the document.  

* Note: It is Not required that documents within the same collection will share the same structure, or have any sort of schema.
  The only requirement for documents to be in the same collection is that they must have the same `@collection` metadata property.  

* For more information see [What is a Collection](../../../client-api/faq/what-is-a-collection)  
{NOTE/}

---

{PANEL: The Documents View:}  

* Shows all collections and the documents each contains.  
* Actions such as create, delete or export a document and more can be done.  


![Figure 1. Documents and Collections](images/documents-and-collections-1.png "Collection 'Categories'")


1.  **Recent**:
  *  Click on `Recent` to see a list of **all** documents from **all** collections in the selected database  
  *  Documents are ordered by the modification time  
<br/>
2.  **Collections**:
  *  The existing **collections** in the selected database  
  *  The number of documents each collection has is indicated  
<br/>
3.  **Documents**:
  *  The list of documents within the selected collection  
  *  Each **column** corresponds to a _property_ in the document json  
  *  Documents are ordered by the modification time  
{PANEL/}

{PANEL}  

![Figure 2. Actions](images/documents-and-collections-2.png "Actions")

1.  
  * **New Document**: Create a new document (in a new collection -or- in the current collection)  
  * **Delete**: Delete selected documents  
  * **Copy**: Copy documents or just documents IDs of selected documents  
<br/>
2.  
  *  **Export CSV**: Export the collection data into a CSV file (visible columns only -or- all documents columns)  
  *  **Display**: Customize which columns to view. A custom column can be added  
<br/>
3.  
  * **Patch**: Patch documents in a collection or in an index. See [Patch Documents](../../../../todo-update-me-later)  
  * **Query**: Query documents in a collection or in an index. See [Query Documents](../../../../todo-update-me-later)  
  * **Conflicts**: View and resolve conflicting documents. See [Conflicts](../../../../todo-update-me-later)  
{PANEL/}

{PANEL}  

Click `Display` to:  

* Select which columns to view  
* Reorder columns viewed  
* Add a custom column  
<br/>

![Figure 3. Manage Displayed Columns](images/documents-and-collections-3.png "Manage Displayed Columns")

{PANEL/}

---

{PANEL: The @hilo Collection:}  

![Figure 4. hilo collection](images/documents-and-collections-4.png "The @hilo Collection")

* Documents in the _@hilo_ collection are created when the _RavenDB client_ (Not from the studio) is creating documents ([using a session](../../../client-api/session/storing-entities))
**without an explicit ID**.  
  For more information about the various documents identifiers that can be generated see [Document Identifiers](../../../client-api/document-identifiers/working-with-document-identifiers)  

* The _'Max'_ property value that shows in the hilo doc represents the largest ID number that was used for a _client generated document_ in that collection.  
  For more information about the HiLo Algorithm see [HiLo Algorithm](../../../client-api/document-identifiers/hilo-algorithm)  
{PANEL/}

---

{PANEL: The @empty Collection:}  

![Figure 5. empty collection](images/documents-and-collections-5.png "The @emtpy Collection")

* A document that has been generated with a **Guid identifier** has no specific collection.  
  Those documents will show under the _@empty_ collection.  

* For more information about the various documents identifiers that can be generated see [Document Identifiers](../../../client-api/document-identifiers/working-with-document-identifiers)  
{PANEL/}

