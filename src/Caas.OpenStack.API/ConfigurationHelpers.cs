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
        public static string GetTenantUrl(string host, string tenant)
        {
            return string.Format(
                "{0}{1}/{2}",
                ConfigurationHelpers.GetBaseUrl(host),
                Constants.CurrentApiVersion,
                tenant
                );
        }

		/// <summary>	Gets tenant URL. </summary>
		/// <remarks>	Anthony, 4/13/2015. </remarks>
		/// <param name="tenant">	The tenant. </param>
		/// <returns>	The tenant URL. </returns>
		public static string GetTenantUrl(string tenant)
		{
			return string.Format(
				"{0}{1}/{2}",
				ConfigurationHelpers.GetBaseUrl(),
				Constants.CurrentApiVersion,
				tenant
				);
		}

        /// <summary>	Gets base URL version. </summary>
        /// <remarks>	Anthony, 4/13/2015. </remarks>
        /// <returns>	The base URL version. </returns>
        public static string GetBaseUrlVersion()
        {
            return string.Format(
                "{0}{1}",
                ConfigurationHelpers.GetBaseUrl(),
                Constants.CurrentApiVersion
                );
        }
	}
}