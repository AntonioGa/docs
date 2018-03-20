﻿# Subscription consumption examples

---

{NOTE: }

In this page:  

[Worker with a specified batch size](../../../client-api/data-subscriptions/subscription-consumption/examples#worker-with-a-specified-batch-size)  
[Client with full exception handling and processing retries](../../../client-api/data-subscriptions/subscription-consumption/examples#client-with-full-exception-handling-and-processing-retries)  
[Subscription that ends when no documents left](../../../client-api/data-subscriptions/subscription-consumption/examples#subscription-that-ends-when-no-documents-left)  
[Worker that processes dynamic objects](../../../client-api/data-subscriptions/subscription-consumption/examples#worker-that-processes-dynamic-objects)  
[Subscription that works with lowest level API](../../../client-api/data-subscriptions/subscription-consumption/examples#subscription-that-works-with-lowest-level-api)  
[Two subscription workers that are waiting for each other](../../../client-api/data-subscriptions/subscription-consumption/examples#two-subscription-workers-that-are-waiting-for-each-other)  

{NOTE/}

---

{PANEL:Worker with a specified batch size}

Here we create a worker, specifying the maximum batch size we want to receive

{CODE subscription_worker_with_batch_size@ClientApi\DataSubscriptions\DataSubscriptions.cs /}

{PANEL/}

{PANEL:Client with full exception handling and processing retries}

Here we implement a client that treats exceptions thrown by worker, and retries creating worker if exception is recoverable.

{CODE reconnecting_client@ClientApi\DataSubscriptions\DataSubscriptions.cs /}

{PANEL/}

{PANEL:Subscription that ends when no documents left}

Here we create a subscription client that runs only up to the point there are no more new documents left to process.  
This is useful for an ad-hoc single use processing, that user wants to be sure is performed entirely

{CODE single_run@ClientApi\DataSubscriptions\DataSubscriptions.cs /}

{PANEL/}


{PANEL:Worker that processes dynamic objects}

Here we create a worker that processes received data as dynamic objects

{CODE dynamic_worker@ClientApi\DataSubscriptions\DataSubscriptions.cs /}

{PANEL/}

{PANEL:Subscription that works with lowest level API}

Here we create a subscription that works with blittable document representation, that can be useful in very high performance scenarios, 
but may be dangerous due to the direct usage of unmanaged memory

{CODE blittable_worker@ClientApi\DataSubscriptions\DataSubscriptions.cs /}

{PANEL/}

{PANEL:Two subscription workers that are waiting for each other}

Here we create two workers:  
* Main worker, with `TakeOver` strategy, that will take over the other one and will take the lead  
* Secondary worker, that will wait for the first one fail (due to machine failure etc.)


Main worker:

{CODE waiting_subscription_1@ClientApi\DataSubscriptions\DataSubscriptions.cs /}

Secondary worker:

{CODE waiting_subscription_2@ClientApi\DataSubscriptions\DataSubscriptions.cs /}

{PANEL/}

## Related articles

- [What are data subscriptions?](../what-are-data-subscriptions)
- [How to **create** a data subscription?](../subscription-creation/how-to-create-data-subscription)
