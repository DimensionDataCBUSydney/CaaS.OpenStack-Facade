// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServerFlavorController.cs" company="">
//   
// </copyright>
// <summary>
//   A controller for handling flavors
//   Dimension Data Cloud has no equivalent, so a 'default' flavor will be returned.
//   .
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System.Threading.Tasks;
using System.Web.Http;
using Caas.OpenStack.API.Interfaces;
using Caas.OpenStack.API.Models.server;

namespace Caas.OpenStack.API.Controllers
{
    /// <summary>	A controller for handling flavors
    /// 			Dimension Data Cloud has no equivalent, so a 'default' flavor will be returned.
    /// 			. </summary>
    /// <remarks>	Anthony, 4/13/2015. </remarks>
    /// <seealso cref="T:System.Web.Http.ApiController"/>
    /// <seealso cref="T:Caas.OpenStack.API.Interfaces.IOpenStackApiFlavorController"/>
	[Authorize]
	[RoutePrefix(Constants.ServerPrefix)]
    public class ServerFlavorController : ApiController, IOpenStackApiFlavorController
    {
		/// <summary>
		/// 	Gets the flavours. OpenStack API Equivalent GET/v2/​{tenant_id}​/flavors. 
		/// </summary>
		/// <remarks>
		/// 	Anthony, 4/13/2015. 
		/// </remarks>
		/// <param name="tenantId">
		/// 	Identifier for the tenant. 
		/// </param>
		/// <returns>
		/// 	The flavours. 
		/// </returns>
		/// <seealso cref="M:Caas.OpenStack.API.Interfaces.IOpenStackApiFlavorController.GetFlavors(string)"/>
		[HttpGet]
		[Route("{tenantId}/flavors")]
		public Task<FlavorCollection> GetFlavors(string tenantId)
		{
			return Task.FromResult(
				new FlavorCollection
				{
					Flavors = new[]
					{
						Flavor.GenerateDefaultFlavor(Request, tenantId) 
					}
				});
		}

		/// <summary>
		/// Gets flavors details OpenStack API Equivalent GET/v2/​{tenant_id}​/flavors/detail. 
		/// </summary>
		/// <remarks>
		/// 	Anthony, 4/13/2015. 
		/// </remarks>
		/// <param name="tenantId">
		/// 	Identifier for the tenant. 
		/// </param>
		/// <returns>
		/// 	The flavors details. 
		/// </returns>
		/// <seealso cref="M:Caas.OpenStack.API.Interfaces.IOpenStackApiFlavorController.GetFlavorsDetails(string)"/>
		[HttpGet]
		[Route("{tenantId}/flavors/detail")]
		public Task<FlavorDetailCollection> GetFlavorsDetails(string tenantId)
		{
			return Task.FromResult(
				new FlavorDetailCollection
				{
					Flavors = new[]
					{
						FlavorDetail.GenerateDefaultFlavor(Request, tenantId)
					}
				});
		}

		/// <summary>
		/// Gets a flavor. OpenStack API Equivalent GET/v2/​{tenant_id}​/flavors/{flavor_id} 
		/// </summary>
		/// <remarks>
		/// 	Anthony, 4/13/2015. 
		/// </remarks>
		/// <param name="tenantId">
		/// 	Identifier for the tenant. 
		/// </param>
		/// <param name="flavorId">
		/// 	Identifier for the flavor. 
		/// </param>
		/// <returns>
		/// 	The flavor. 
		/// </returns>
		/// <seealso cref="M:Caas.OpenStack.API.Interfaces.IOpenStackApiFlavorController.GetFlavor(string,string)"/>
		[HttpGet]
		[Route("{tenantId}/flavors/{flavorId}")]
		public Task<FlavorDetailResponse> GetFlavor(string tenantId, string flavorId)
		{
			return Task.FromResult(
				new FlavorDetailResponse
				{
					Flavor = FlavorDetail.GenerateDefaultFlavor(Request, tenantId)
				});
		}
    }
}
