﻿# Manage Your Server : Cluster

The first thing you'll see when starting a new server is this:   
![Figure 0. Studio. Manage Your Server. Opening Screen.](images/cluster-0.png)

Then, you'll need to select `Create cluster` and supply the server URL and credentials (optional).   
![Figure 1. Studio. Manage Your Server. Create Cluster.](images/cluster-1.png)

You can then add the other nodes to the cluster by pressing the `Add another server to cluster` button. 
The default leader will be the node from which the cluster was first created.   
![Figure 2. Studio. Manage Your Server. One Node Cluster.](images/cluster-2.png)
![Figure 3. Studio. Manage Your Server. Add More Nodes.](images/cluster-3.png)

After adding a few nodes to the cluster it should look something like this:   
![Figure 5. Studio. Manage Your Server. Five Node Cluster.](images/cluster-5.png)

In addition to the expected options like editing a node's address or leaving the cluster, 
we have added some `Emergency cluster operations`. These are operations that are not part of 
Raft and are provided only for out-of-the-ordinary cases and should only be used wisely 
(and with caution) by the admin.   
![Figure 6. Studio. Manage Your Server. Emergency Operations.](images/cluster-6.png)

A node can ask to `Secede from cluster`, which means it will be disconnected and removed from 
the cluster topology. A side effect is that the node will be left with its own single-node cluster.   

Another option is the ability to `Kidnap a node - force a node to the cluster`, even if it's in 
another cluster. In that case, the new node will be promotable until its state is synced with 
the rest of the cluster. Only then it will get voting privileges.   

The third option is `remove the cluster entirely and perform cleanup`. This option is needed 
after a node secedes from the cluster and is left with a cluster of its own. It removes the 
clustering information from the node, turning it into a normal non-cluster node.   

When the cluster is up and running, you can click on `Manage your server -> Server topology -> Fetch topology` 
and get a map of your cluster.   

{NOTE:Clustering and Replication}
When in a cluster, every new database you will create will have the replication bundle enabled by default. 
This is done because in a cluster, not all operations pass through the Raft (Rachis) algorithm. Some 
operations like creating and deleting databases do, but document replication for example is done  through 
the replication mechanism instead. In the cluster case - the replication topology is a full connected 
graph where all nodes are connected to all other nodes (clique).   
{NOTE/}   
![Figure 4. Studio. Manage Your Server. Replication Enabled by Default.](images/cluster-4.png)   
   
{NOTE:Hot Spare behavior under clustering}
If not activated, the hot spare node will not have voting privileges, thus it cannot be considered for a quorum. 
After activation, the hot spare node becomes promotable and can be elected as a leader. When activation expires, 
if the hot spare node is the leader, it will gracefully (notifying the other cluster nodes) step down.   
{NOTE/} 
  
{WARNING:Warning}
Setting replication between nodes in different clusters is not supported. You may however, define 
replication to a node outside the cluster, as long as it doesn't belong to a different cluster.
{WARNING/}


## Related articles

- [Clustering: Overview](../../server/scaling-out/clustering/clustering-overview)
- [Clustering: Rachis](../../server/scaling-out/clustering/what-is-rachis)

