using System;

namespace Caas.OpenStack.API.UriFactories
{
	/// <summary>	A server URI factory. </summary>
	/// <remarks>	Anthony, 4/13/2015. </remarks>
	public static class ServerUriFactory
	{
		/// <summary>	Gets the server URI. </summary>
		/// <remarks>	Anthony, 4/13/2015. </remarks>
		/// <param name="host">	   	The host. </param>
		/// <param name="tenantId">	The tenant identifier. </param>
		/// <param name="id">	   	The identifier. </param>
		/// <returns>	The server URI. </returns>
		public static string GetServerUri(string host, string tenantId, string id)
		{
			return String.Format(
				"{0}{1}/{2}/servers/{3}",
				ConfigurationHelpers.GetBaseUrl(host),
				Constants.CurrentApiVersion,
				tenantId,
				id
				);
		}

		/// <summary>	Gets flavor URI. </summary>
		/// <remarks>	Anthony, 4/13/2015. </remarks>
		/// <param name="host">	   	The host. </param>
		/// <param name="tenantId">	The tenant identifier. </param>
		/// <param name="id">	   	The identifier. </param>
		/// <returns>	The flavor URI. </returns>
		public static string GetFlavorUri(string host, string tenantId, int id)
		{
			return String.Format(
				"{0}{1}/{2}/flavors/{3}",
				ConfigurationHelpers.GetBaseUrl(host),
				Constants.CurrentApiVersion,
				tenantId,
				id
				);
		}
	}
}