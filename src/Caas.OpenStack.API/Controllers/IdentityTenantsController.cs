// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IdentityTenantsController.cs" company="">
//   
// </copyright>
// <summary>
//   A controller for handling identity tenants.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Caas.OpenStack.API.Interfaces;
using Caas.OpenStack.API.Models;
using Caas.OpenStack.API.Models.identity;

namespace Caas.OpenStack.API.Controllers
{
    /// <summary>	A controller for handling identity tenants. </summary>
    /// <remarks>	Anthony, 4/16/2015. </remarks>
    /// <seealso cref="T:System.Web.Http.ApiController"/>
    /// <seealso cref="T:Caas.OpenStack.API.Interfaces.IOpenStackApiTenantsController"/>
    public class IdentityTenantsController : ApiController, IOpenStackApiTenantsController
    {
	    /// <summary>	Gets the tenants GET/v2.0/tenants. </summary>
	    /// <remarks>	Anthony, 4/16/2015. </remarks>
	    /// <returns>	The tenants. </returns>
	    /// <seealso cref="M:Caas.OpenStack.API.Interfaces.IOpenStackApiTenantsController.GetTenants()"/>
	    [HttpGet]
		[Route("tenants")]
		[Route(Constants.CurrentApiVersion + "/tenants")]
		[Route(Constants.CurrentApiVersionLong + "/tenants")]
	    public Task<TenantCollectionResponse> GetTenants()
	    {
		    return Task.FromResult(
			    new TenantCollectionResponse
			    {
				    Tenants = new List<Tenant>
				    {
						Tenant.DefaultTenant
				    }, 
					TenantsLinks = new RestLink[0]
			    });
	    }

	    /// <summary>
	    /// 	Gets tenant by name. 
	    /// </summary>
	    /// <remarks>
	    /// 	Anthony, 4/16/2015. 
	    /// </remarks>
	    /// <param name="tenantName">
	    /// 	Name of the tenant. 
	    /// </param>
	    /// <returns>
	    /// 	The tenant by name. 
	    /// </returns>
	    /// <seealso cref="M:Caas.OpenStack.API.Interfaces.IOpenStackApiTenantsController.GetTenantByName(string)"/>
	    public Task<TenantResponse> GetTenantByName(string tenantName)
	    {
		    throw new NotImplementedException();
	    }

	    /// <summary>
	    /// 	Gets tenant by identifier. 
	    /// </summary>
	    /// <remarks>
	    /// 	Anthony, 4/16/2015. 
	    /// </remarks>
	    /// <param name="tenantId">
	    /// 	Identifier for the tenant. 
	    /// </param>
	    /// <returns>
	    /// 	The tenant by identifier. 
	    /// </returns>
	    /// <seealso cref="M:Caas.OpenStack.API.Interfaces.IOpenStackApiTenantsController.GetTenantById(string)"/>
	    public Task<TenantResponse> GetTenantById(string tenantId)
	    {
		    throw new NotImplementedException();
	    }
    }
}
