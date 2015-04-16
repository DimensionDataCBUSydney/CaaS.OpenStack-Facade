// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IOpenStackApiTenantsController.cs" company="">
//   
// </copyright>
// <summary>
//   Interface for open stack API tenants controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System.Threading.Tasks;
using Caas.OpenStack.API.Models.identity;

namespace Caas.OpenStack.API.Interfaces
{
	/// <summary>	Interface for open stack API tenants controller. </summary>
	/// <remarks>	Anthony, 4/16/2015. </remarks>
	public interface IOpenStackApiTenantsController
	{
		/// <summary>	Gets the tenants
		/// 			GET/v2.0/tenants. </summary>
		/// <returns>	The tenants. </returns>
		Task<TenantCollectionResponse> GetTenants();

		/// <summary>
		/// 	Gets tenant by name. 
		/// </summary>
		/// <param name="tenantName">
		/// 	Name of the tenant. 
		/// </param>
		/// <returns>
		/// 	The tenant by name. 
		/// </returns>
		Task<TenantResponse> GetTenantByName(string tenantName);

		/// <summary>
		/// 	Gets tenant by identifier. 
		/// </summary>
		/// <param name="tenantId">
		/// 	Identifier for the tenant. 
		/// </param>
		/// <returns>
		/// 	The tenant by identifier. 
		/// </returns>
		Task<TenantResponse> GetTenantById(string tenantId);
	}
}
