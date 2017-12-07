# Attachments : Get

There are few methods that allow you to download attachments from a database:   
- [GetAttachment](../../../client-api/session/attachments/get#getattachment)   
- [GetAttachments](../../../client-api/session/attachments/get#getattachments)   

**session.Advanced.Attachments.Get** can be used to download an attachment.
**session.Advanced.Attachments.GetNames** can be used to all attachment names that attached to a document.
**session.Advanced.Attachments.GetRevision** can be used to download an attachment of a revision document.
**session.Advanced.Attachments.Exists** can be used to determine if an attachment is exists on a document.

### Syntax

{CODE GetSyntax@ClientApi\Session\Attachments\Attachments.cs /}

### Example

{CODE-TABS}
{CODE-TAB:csharp:Sync GetAttachment@ClientApi\Session\Attachments\Attachments.cs /}
{CODE-TAB:csharp:Async GetAttachmentAsync@ClientApi\Session\Attachments\Attachments.cs /}
{CODE-TABS/}

## Related articles

- [PutAttachment](../../../client-api/session/attachments/put)  
- [DeleteAttachment](../../../client-api/session/attachments/delete)  
