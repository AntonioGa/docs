# Security : Authentication : Client Certificate Usage

In previous sections we described how to obtain a server certificate and how to configure RavenDB to use it. In this section we will cover how to use client certificates to connect to a RavenDB server.

## Obtaining Your First Client Certificate

When RavenDB is running with a server certificate for the first time, there are no client certificates registered in the server yet. The first action an administrator will do is to generate/register an admin client certificate.

{NOTE This operation is only required when doing a **manual** secured setup. If you are using the automated [Setup Wizard](../../../start/installation/setup-wizard), an admin client certificate will be generated for you as part of the wizard. /}

### Example I - Using the RavenDB CLI

If you have access to the server, the simplest way is to use the RavenDB CLI:

{CODE-BLOCK:plain}
ravendb> generateClientCert <name> <path-to-output-folder> [password]
{CODE-BLOCK/}

Or if you wish to use your own client certificate:

{CODE-BLOCK:plain}
ravendb> trustClientCert <name> <path-to-pfx> [password]
{CODE-BLOCK/}

### Example II - Using Powershel and Wget in Windows 

You can use a client to make an HTTP request to the server. At this point you only have a **server certificate** and you will use it (acting as the client certificate).

Assume we started the server with the following settings.json:

{CODE-BLOCK:json}
{
    "ServerUrl": "https://rvn-srv-1:8080",
    "Setup.Mode": "None",
    "DataDir": "c:/RavenData",
    "Security.Certificate": {
        "Path": "c:/secrets/server.pfx",
        "Password": "s3cr7t p@$$w0rd"
    }
} 
{CODE-BLOCK/}

We can use wget to request a `Cluster Admin` certificate. This will be the payload of the POST request:

{CODE-BLOCK:json}
{
    "Name": "cluster.admin.client.certificate",
    "SecurityClearance": "ClusterAdmin",
    "Password": "p@$$w0rd"
} 
{CODE-BLOCK/}

First, load the server certificate:

{CODE-BLOCK:powershell}
$cert = Get-PfxCertificate -FilePath c:/secrets/server.pfx
{CODE-BLOCK/}

Then make the request:

{CODE-BLOCK:powershell}
wget -UseBasicParsing -Method POST -Certificate $cert -OutFile "cluster.admin.cert.zip" -Body '{"Name": "cluster.admin.client.certificate","SecurityClearance": "ClusterAdmin","Password": "p@$$w0rd"}' "https://rvn-srv-1:8080/admin/certificates"
{CODE-BLOCK/}

### Example III : Using cURL in Linux

At this point you only have a **server certificate** and you will use it (acting as the client certificate).  
First, we will convert the .pfx certificate to .pem:
{CODE-BLOCK:bash}
openssl pkcs12 -in cluster.server.certificate.example.pfx -out server.pem -clcerts
{CODE-BLOCK/}

{NOTE You must provide a password when creating the .pem file, cURL will only accept a password protected certificate. /}

Then make the request:
{CODE-BLOCK:bash}
curl -X POST -H "Content-Type: application/json" -d '{"Name": "cluster.admin.client.certificate","SecurityClearance": "ClusterAdmin","Password": "p@$$w0rd"}' -o cluster.admin.cert.zip https://rvn-srv-1:8080/admin/certificates --cert /home/secrets/server.pem:pem_password
{CODE-BLOCK/}

### Example IV : Using the RavenDB Client

Wiring a certificate in the RavenDB Client is described in the [setting up authentication and authorization](../../../client-api/setting-up-authentication-and-authorization) section of the Client API.
