﻿using Raven.Client.Documents;
using Sparrow;

namespace Raven.Documentation.Samples.ClientApi.Configuration
{
	public class Conventions
	{
		public Conventions()
		{
			#region conventions_1
		    using (var store = new DocumentStore()
		    {
		        Conventions =
		        {
                // customizations go here
		        }
		    }.Initialize())
		    {

		    }
			#endregion
		}

	    public void Examples()
	    {
	        var store = new DocumentStore()
	        {
	            Conventions =
	            {
	                #region MaxHttpCacheSize
	                MaxHttpCacheSize = new Size(256, SizeUnit.Megabytes)
	                #endregion
	                ,
	                #region MaxNumberOfRequestsPerSession
	                MaxNumberOfRequestsPerSession = 10
	                #endregion
	                ,
	                #region UseOptimisticConcurrency
	                UseOptimisticConcurrency = true
	                #endregion
	                ,
	                #region DisableTopologyUpdates
                    DisableTopologyUpdates = false
	                #endregion
                    ,
	                #region SaveEnumsAsIntegers
                    SaveEnumsAsIntegers = true
	                #endregion
	            }
	        };
	    }
	}
}
