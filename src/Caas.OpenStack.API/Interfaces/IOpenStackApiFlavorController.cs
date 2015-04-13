using System.Threading.Tasks;
using Caas.OpenStack.API.Models.server;

namespace Caas.OpenStack.API.Interfaces
{
	/// <summary>	Interface for open stack API flavour controller. </summary>
	/// <remarks>	Anthony, 4/13/2015. </remarks>
	public interface IOpenStackApiFlavorController
	{
		/// <summary>	Gets the flavours. 
		/// 			OpenStack API Equivalent GET/v2/​{tenant_id}​/flavors </summary>
		/// <remarks>	Anthony, 4/13/2015. </remarks>
		/// <param name="tenantId">	Identifier for the tenant. </param>
		/// <returns>	The flavours. </returns>
		Task<FlavorCollection> GetFlavors(string tenantId);

		/// <summary>	Gets flavors details
		/// 			OpenStack API Equivalent GET/v2/​{tenant_id}​/flavors/detail. </summary>
		/// <param name="tenantId">	Identifier for the tenant. </param>
		/// <returns>	The flavors details. </returns>
		Task<FlavorCollection> GetFlavorsDetails(string tenantId);

		/// <summary>	Gets a flavor.
		/// 			OpenStack API Equivalent GET/v2/​{tenant_id}​/flavors/{flavor_id} </summary>
		/// <param name="tenantId">	Identifier for the tenant. </param>
		/// <param name="flavorId">	Identifier for the flavor. </param>
		/// <returns>	The flavor. </returns>
		Task<FlavorResponse> GetFlavor(string tenantId, string flavorId);
	}
}