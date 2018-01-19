# Server Configuration : Security

The following configuration values allow you to control the desired level of security in a RavenDB server. For a more detailed explanation, please visit the [Security Section](../security/overview).

{PANEL:Security.Certificate.Path}

The path to .pfx certificate file. If specified, RavenDB will use HTTPS/SSL for all network activities.   
Certificate setting priority order:   
1. Path   
2. Executable   

- **Type**: `string`
- **Default**: `null`
- **Scope**: Server-wide only

{PANEL/}

{PANEL:Security.Certificate.Password}

The (optional) password of the .pfx certificate file.

- **Type**: `string`
- **Default**: `null`
- **Scope**: Server-wide only

{PANEL/}

{PANEL:Security.Certificate.Exec}

A command or executable providing a .pfx certificate file. If specified, RavenDB will use HTTPS/SSL for all network activities. The certificate path setting takes precedence over executable configuration option.

- **Type**: `string`
- **Default**: `null`
- **Scope**: Server-wide only

{PANEL/}

{PANEL:Security.Certificate.Exec.Arguments}

The command line arguments for the 'Security.Certificate.Exec' command or executable.

- **Type**: `string`
- **Default**: `null`
- **Scope**: Server-wide only

{PANEL/}

{PANEL:Security.Certificate.Exec.TimeoutInSec}

The number of seconds to wait for the certificate executable to exit.

- **Type**: `int`
- **Default**: `30`
- **Scope**: Server-wide only

{PANEL/}

{PANEL:Security.Certificate.LetsEncrypt.Email}

The E-mail address associated with the Let's Encrypt certificate. Used for renewal requests.

- **Type**: `string`
- **Default**: `null`
- **Scope**: Server-wide only

{PANEL/}

{PANEL:Security.MasterKey.Path}

The path of the (512-bit) Master Key. If specified, RavenDB will use this key to protect secrets.

- **Type**: `string`
- **Default**: `null`
- **Scope**: Server-wide only

{PANEL/}

{PANEL:Security.MasterKey.Exec}

A command or executable to run which will provide a (512-bit) Master Key, If specified, RavenDB will use this key to protect secrets.

- **Type**: `string`
- **Default**: `null`
- **Scope**: Server-wide only

{PANEL/}

{PANEL:Security.MasterKey.Exec.Arguments}

The command line arguments for the 'Security.MasterKey.Exec' command or executable. 

- **Type**: `string`
- **Default**: `null`
- **Scope**: Server-wide only

{PANEL/}

{PANEL:Security.MasterKey.Exec.TimeoutInSec}

The number of seconds to wait for the Master Key executable to exit.

- **Type**: `int`
- **Default**: `30`
- **Scope**: Server-wide only

{PANEL/}

{PANEL:Security.UnsecuredAccessAllowed}

If authentication is disabled, set address range type for which server access is unsecured (`None | Local | PrivateNetwork | PublicNetwork`).

- **Type**: `flags`
- **Default**: `Local`
- **Scope**: Server-wide or only

{PANEL/}

{PANEL:Security.DoNotConsiderMemoryLockFailureAsCatastrophicError}

Whether RavenDB will consider memory lock error to be catastrophic. This is used with encrypted databases to ensure that temporary buffers are never written to disk and are locked to memory. Setting this to true is not recommended and should be done only after proper security analysis has been performed.

- **Type**: `bool`
- **Default**: `false`
- **Scope**: Server-wide or per database

{WARNING Use with caution. /}

{PANEL/}
