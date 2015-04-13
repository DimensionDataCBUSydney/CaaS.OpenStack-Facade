using System;

namespace Caas.OpenStack.API.UriFactories
{
	/// <summary>	An URL generator. </summary>
	/// <remarks>	Anthony, 4/13/2015. </remarks>
	public static class ImageUriFactory
	{
		/// <summary>	Gets image URI. </summary>
		/// <remarks>	Anthony, 4/13/2015. </remarks>
		/// <param name="tenantId">	Identifier for the tenant. </param>
		/// <param name="imageId"> 	Identifier for the image. </param>
		/// <returns>	The image URI. </returns>
		public static string GetImageUri(string tenantId, string imageId)
		{
			return String.Format(
				"{0}{1}/{2}/images/{3}",
				ConfigurationHelpers.GetBaseUrl(),
				Constants.CurrentApiVersion,
				tenantId,
				imageId
				);
		}

        /// <summary>	Gets image URI. </summary>
        /// <remarks>	Anthony, 4/13/2015. </remarks>
        /// <param name="host">	   	The host. </param>
        /// <param name="tenantId">	Identifier for the tenant. </param>
        /// <param name="imageId"> 	Identifier for the image. </param>
        /// <returns>	The image URI. </returns>
        public static string GetImageUri(string host, string tenantId, string imageId)
        {
            return String.Format(
                "{0}{1}/{2}/images/{3}",
                ConfigurationHelpers.GetBaseUrl(host),
                Constants.CurrentApiVersion,
                tenantId,
                imageId
                );
        }
	}
}