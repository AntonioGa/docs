﻿# Operations : Server : How to Get Server-Wide Client Configuration

**GetServerWideClientConfigurationOperation** is used to return a server-wide client configuratio, which is saved on the server and overrides the client behavior. 

{NOTE `ClientConfiguration` defined at database level overrides server-wide client configuration. /}

## Syntax

{CODE config_1_0@ClientApi\Operations\Server\ClientConfig.cs /}

| Return Value | |
| ------------- | ---- |
| [ClientConfiguration](../../../glossary/ClientConfiguration) | configuration which will be used by the RavenDB Client |

## Example

{CODE config_1_2@ClientApi\Operations\Server\ClientConfig.cs /}

## Related Articles

- [How to get **client configuration**?](../../../../client-api/operations/maintenance/configuration/get-client-configuration)
