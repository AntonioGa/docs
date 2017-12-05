# Attachments : Put

In order to put an attachment in RavenDB you need to create a document and than you can attach an attachment to the document using the `Advanced.Attachments.Store` method.
Note that attachments are trnsactional and would be save when you call `session.SaveChanges`.

## Syntax

The can store an attachment using the folloinwg `session.Advanced.Attachments.Store` methods:

{CODE StoreSyntax@ClientApi\Session\Attachments.cs /}

## Example

{CODE StoreAttachment@ClientApi\Session\Attachments.cs /}

{CODE StoreAttachmentAsync@ClientApi\Session\Attachments.cs /}

## Related articles

- [GetAttachment](../../../client-api/commands/attachments/get)  
- [DeleteAttachment](../../../client-api/commands/attachments/delete
