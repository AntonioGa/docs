#Conventions

Conventions give you an ability to customize the Client API behavior. They are accessible from `DocumentStore` object:

{CODE conventions_1@ClientApi\Configuration\Conventions.cs /}

You will find many settings to overwrite, allowing you to adjust the client according to your needs. The conventions apply to many different client behaviors, some of them are grouped and described in the separate articles of this section.

{INFO All customizations need to be set before `DocumentStore.Initialize()` is called. /}

##MaxHttpCacheSize

If you need to modify the maximum http cache size, you can use the following setting:

{CODE MaxHttpCacheSize@ClientApi\Configuration\Conventions.cs /}

{NOTE: Default size}

The default value of this setting is configured as follows:

* running on 64 bits:
  * if usable memory is lower than or equal to 3GB: 64MB,
  * if usable memory is greater than 3GB and lower than or equal to 6GB: 128MB,
  * if usable memory is greater than 6GB: 512MB,

* running on 32 bits: 32MB.

The cache is created per database you use.

{NOTE/}

{NOTE: Disable caching} 

To disable the caching you can set the `MaxHttpCacheSize` value to zero:

{CODE disable_cache@ClientApi\Configuration\Conventions.cs /}

**In this scenario all the requests will be sent to the server to fetch the data.**

{NOTE/}

## MaxNumberOfRequestsPerSession

Gets or sets maximum number of GET requests per session. Default: `30`.

{CODE MaxNumberOfRequestsPerSession@ClientApi\Configuration\Conventions.cs /}

##UseOptimisticConcurrency

Controls whether optimistic concurrency is set to true by default for all future sessions. Default: `false`.

{CODE UseOptimisticConcurrency@ClientApi\Configuration\Conventions.cs /}

##RequestTimeout

It allows to define the global request timeout value for all `RequestExecutors` created per database. Default: `null`.

{CODE RequestTimeout@ClientApi\Configuration\Conventions.cs /}

##DisableTopologyUpdates

Forces to disable updates of database topology. Default: `false`.

{CODE DisableTopologyUpdates@ClientApi\Configuration\Conventions.cs /}

##SaveEnumsAsIntegers

It determines if C# `enum` types should be saved as integers or strings and instruct the LINQ provider to query enums as integer values. Default: `false`.

{CODE SaveEnumsAsIntegers@ClientApi\Configuration\Conventions.cs /}
