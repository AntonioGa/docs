# What is a public API?

In RavenDB we are doing our best to not introduce any breaking changes in the public API between minor versions of our client API. This means that the upgrade between version 3.0.A and 3.0.B or even 3.C.D should be smooth.

## What is considered a public API?

Very common question that we are getting is what we consider a public API. The answer to this question is not straightforward, because our .NET Client contains two DLLs

- `Raven.Abstractions.dll`
- `Raven.Client.Lightweight.dll`

And a lot of types in those DLLs are shared between Client, Tools and Server so naturally some changes between versions might occur. But does this mean that we are chaning the public API? In our opinion no, because there is a set of interfaces/methods/types that we consider unchangable.

Those interfaces/methods/types are related to the most common actions of the client that cover 99,9% of the usage cases. What are those you might ask? Those are related to the **session actions**, including **advanced session operations**, **low-level database commands for manipulating documents and attachments** and **related types**. So any changes here (excluding new features) should be considered a bug, but this also does not mean that the changes will not occur at all, they can, but those will be a backward-compatibile changes e.g. we might add an optional parameter to method X that will not brake current behavior but will extend the functionality.