# What are Attachments

In RavenDB, attachments are binary streams which can be bound to an existing document. 
Each attachment has a name, and you can specify the content type (`image/png` or `application/pdf` for example).

A document can have any number of attachments.

Each attachment is bound to an existing document. In order to get a document, you'll need to specify the document ID and the attachment name. 
What's great in this approach is that you can specify the attachment's metadata in the document itself, and this document can be queried as any other document.

## Example I

In order to store an album of pictures in RavenDB, you can create the following "albums/1" document:

{CODE-BLOCK:json}
{
    "UserId": "users/1",
    "Name": "Holidays",
    "Description": "Holidays travel pictures of the all family",
    "Tags": ["Holidays Travel", "All Family"],
    "@metadata": {
        "@collection": "Albums"
    }
}
{CODE-BLOCK/}

This document can have the following attachments:

- Name: `001.jpg`, Content-Type: `image/jpeg`
- Name: `002.jpg`, Content-Type: `image/jpeg`
- Name: `003.jpg`, Content-Type: `image/jpeg`
- Name: `004.mp4`, Content-Type: `video/mp4`

## Example II

You can store a `users/1` document and attach to it to a profile picture.
When requesting the document from the server the results would be:

{CODE-BLOCK:json}
{
  "Name": "Hibernating Rhinos",
  "@metadata": {
    "@attachments": [
      {
        "ContentType": "image/png",
        "Hash": "iFg0o6D38pUcWGVlP71ddDp8SCcoEal47kG3LtWx0+Y=",
        "Name": "profile.png",
        "Size": 33241
      }
    ],
    "@collection": "Users",
    "@change-vector": "A:1061-D11EJRPTVEGKpMaH2BUl9Q",
    "@flags": "HasAttachments",
    "@id": "users/1",
    "@last-modified": "2017-12-05T12:36:24.0504021Z"
  }
}
{CODE-BLOCK/}

Note that this document has an HasAttachments flag and an @attachments array with the attachment's info.

You can see the attachment's name, content type, hash and size.

{NOTE We would store the attachment streams by the hash, so if many attachments have the same hash, their streams would be stored just once. /}

## Transaction Support

In RavenDB, attachment and documents are stored as ACID transaction: You either get all of them saved to disk or none.

## Revisions and Attachments

When the revisions feature is turned on in your database, each attachment addition to a document (or deletion from a document) will create a new revision of the document, 
as there will be a change to the document's metadata, as shown in example #2. 

## Related articles

### Attachments

- [Storing](../../../client-api/session/attachments/storing)
- [Loading](../../../client-api/session/attachments/loading)
- [Deleting](../../../client-api/session/attachments/deleting)
