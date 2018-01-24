﻿# Operations : How to Put Client Configuration

**PutClientConfigurationOperation** is used to save a client configuration on the server. It allows you to override client's settings remotely. 

## Syntax

{CODE config_2_0@ClientApi\Operations\ClientConfig.cs /}

| Return Value | | |
| ------------- | ----- | ---- |
| **configuration** | [ClientConfiguration](../../../glossary/ClientConfiguration) | configuration which will be used by client API |

## Example

{CODE config_2_2@ClientApi\Operations\ClientConfig.cs /}

## Related Articles

- [How to get server-wide **client configuration**?](../../../client-api/operations/server/get-serverwide-client-configuration-operation)
- [How to put server-wide **client configuration**?](../../../client-api/operations/server/put-serverwide-client-configuration-operation)
