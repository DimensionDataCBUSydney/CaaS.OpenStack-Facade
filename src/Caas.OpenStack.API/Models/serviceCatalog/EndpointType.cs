namespace Caas.OpenStack.API.Models.serviceCatalog
{
	/// <summary>	Values that represent endpoint types. </summary>
	/// <remarks>	Anthony, 4/13/2015. </remarks>
	public enum EndpointType
	{
		/// <summary>	An enum constant representing the compute option. </summary>
		compute,

		/// <summary>	An enum constant representing the network option. </summary>
		network,

		/// <summary>	An enum constant representing the storage option. </summary>
		storage,

        /// <summary>	An enum constant representing the identity option. </summary>
        identity
	}
}