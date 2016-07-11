# ETL (Extract Transform Load)

Another replication feature in RavenDB is the ability to replicate only specific collections, and the ability to transform the outgoing data as it goes out.

## Why use ETL?
There are several reasons why you'll want to use this feature.   
In terms of deployment, it gives you an easy way to replicate parts of a database's data to a number of other 
databases, without requiring you to send the full details. A typical example would be a product catalog that 
is shared among multiple tenants, where each tenant can modify the products or add new ones.

Another example would be to have the production database replicate backward to the staging database, 
with certain fields that are masked so the development / QA team can work with a realistic dataset.

{WARNING: Warning: Failover behavior}
An important consideration with ETL is that because the data is filtered and possibly transformed, 
a destination that is using this feature isn't a viable fallback target, and it will not be considered as such by the client. 
If you want failover, you need to have multiple replicas, some with the full data set and some with the filtered data.
{WARNING/}

## Related articles

- [Studio : Settings : ETL (Extract Transform Load)](../../studio/overview/settings/etl)
