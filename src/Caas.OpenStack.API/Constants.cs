using System;

namespace Caas.OpenStack.API
{
	/// <summary>	Constants for this build. </summary>
	/// <remarks>	Anthony, 4/13/2015. </remarks>
	public static class Constants
	{
		/// <summary>	The current API version. </summary>
		public const string CurrentApiVersion = "v2";

        /// <summary>	The current API version (full). </summary>
        public const string CurrentApiVersionLong = "v2.0";

		/// <summary>	The current images API version. </summary>
		public const string CurrentServerApiVersion = "v2";

		/// <summary>	The current images API version. </summary>
		public const string CurrentImagesApiVersion = "v2";

		/// <summary>	The current networking API version. </summary>
		public const string CurrentNetworkingApiVersion = "v2";

		/// <summary>	The network prefix. </summary>
		public const string NetworkPrefix = "network/" + CurrentNetworkingApiVersion;

		/// <summary>	The image prefix. </summary>
		public const string ImagePrefix = "image/" + CurrentImagesApiVersion;

		/// <summary>	The server prefix. </summary>
		public const string ServerPrefix = "server/" + CurrentServerApiVersion;
	}
}