﻿# Operations : How to get client configuration?

**GetClientConfigurationOperation** is used to return client configuration, which is saved on server and overrides client behavior. 

## Syntax

{CODE config_1_0@ClientApi\Operations\ClientConfig.cs /}

{CODE config_1_1@ClientApi\Operations\ClientConfig.cs /}

| Return Value | | |
| ------------- | ----- | ---- |
| **Etag** | string | Etag of configuration |
| **Configuration** | [ClientConfiguration](../../../glossary/ClientConfiguration) | configuration which will be used by client API |

## Example

{CODE config_1_2@ClientApi\Operations\ClientConfig.cs /}

## Related articles

- [How to get server-wide **client configuration**?](../../../client-api/operations/server/get-serverwide-client-configuration-operation)
