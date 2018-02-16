# Configuration : Memory Options

{PANEL:Memory.LowMemoryLimitInMb}

The minimum amount of available memory RavenDB will attempt to achieve (free memory lower than this value will trigger low memory behavior).

- **Type**: `int`
- **Default**: minimum of either `10% of total physical memory` or `2GB`
- **Scope**: Server-wide only

{PANEL/}

{PANEL:Memory.MinimumFreeCommittedMemoryPercentage}

EXPERT: The minimum amount of committed memory that RavenDB will attempt to ensure remains available. Reducing this value too much may cause RavenDB to fail if there is not enough memory available for the operation system to handle operations.

- **Type**: `float`
- **Default**: `0.05f`
- **Scope**: Server-wide only

{PANEL/}
