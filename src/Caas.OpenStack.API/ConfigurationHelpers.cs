using System;
using System.Configuration;

namespace Caas.OpenStack.API
{
	/// <summary>	A configuration helpers. </summary>
	/// <remarks>	Anthony, 4/13/2015. </remarks>
	public static class ConfigurationHelpers
	{
		/// <summary>
		/// Gets the base URL for this endpoint.
		/// </summary>
		/// <returns>The Url</returns>
		public static string GetBaseUrl()
		{
			return ConfigurationManager.AppSettings["BaseUrl"];
		}

        /// <summary>	Gets the base URL for this endpoint. </summary>
        /// <remarks>	Anthony, 4/13/2015. </remarks>
        /// <param name="host">	The host. </param>
        /// <returns>	The Url. </returns>
        public static string GetBaseUrl(string host)
        {
            return String.Format("http://{0}/", host); // TODO : Support for HTTPS
        }

		/// <summary>	Gets API URI. </summary>
		/// <remarks>	Anthony, 4/13/2015. </remarks>
		/// <returns>	The API URI. </returns>
		public static Uri GetApiUri()
		{
			return new Uri(ConfigurationManager.AppSettings["ApiEndpoint"]);
		}

        /// <summary>	Gets tenant URL. </summary>
        /// <remarks>	Anthony, 4/13/2015. </remarks>
        /// <param name="host">  	The host. </param>
        /// <param name="tenant">	The tenant. </param>
        /// <returns>	The tenant URL. </returns>
        public static string GetServerUrl(string host, string tenant)
        {
            return string.Format(
                "{0}{1}/{2}",
                ConfigurationHelpers.GetBaseUrl(host),
                Constants.ServerPrefix,
                tenant
                );
        }

		/// <summary>	Gets image URL. </summary>
		/// <remarks>	Anthony, 4/15/2015. </remarks>
		/// <param name="host">  	The host. </param>
		/// <param name="tenant">	The tenant. </param>
		/// <returns>	The image URL. </returns>
		public static string GetImageUrl(string host, string tenant)
		{
			return string.Format(
				"{0}{1}/{2}",
				ConfigurationHelpers.GetBaseUrl(host),
				Constants.ImagePrefix,
				tenant
				);
		}

		/// <summary>	Gets network URL. </summary>
		/// <remarks>	Anthony, 4/15/2015. </remarks>
		/// <param name="host">  	The host. </param>
		/// <returns>	The network URL. </returns>
		public static string GetNetworkUrl(string host)
		{
			return string.Format(
				"{0}{1}",
				ConfigurationHelpers.GetBaseUrl(host),
				Constants.NetworkPrefix
				);
		}
	}
}