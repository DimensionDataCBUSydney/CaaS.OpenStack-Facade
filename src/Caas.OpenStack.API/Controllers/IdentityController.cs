// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IdentityController.cs" company="">
//   
// </copyright>
// <summary>
//   A controller for handling identities.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Caas.OpenStack.API.Models.identity;
using Caas.OpenStack.API.Models.serviceCatalog;
using DD.CBU.Compute.Api.Client.Interfaces;
using DD.CBU.Compute.Api.Contracts.Datacenter;
using DD.CBU.Compute.Api.Contracts.Directory;

namespace Caas.OpenStack.API.Controllers
{
	/// <summary>	A controller for handling identities. </summary>
	/// <remarks>	Anthony, 4/13/2015. </remarks>
	/// <seealso cref="T:System.Web.Http.ApiController"/>
	public class IdentityController : ApiController
	{
		/// <summary>	The compute client. </summary>
		private readonly IComputeApiClient _computeClient;

		/// <summary>
		/// Initialises a new instance of the <see cref="IdentityController"/> class. 
		/// Initializes a new instance of the <see cref="ServerController"/> class.
		/// </summary>
		/// <param name="apiClient">
		/// The API client.
		/// </param>
		public IdentityController(Func<Uri, IComputeApiClient> apiClient)
		{
			_computeClient = apiClient(ConfigurationHelpers.GetApiUri());
		}

		/// <summary>
		/// 	(An Action that handles HTTP POST requests) issue token. 
		/// </summary>
		/// <remarks>
		/// 	Anthony, 4/13/2015. 
		/// </remarks>
		/// <param name="request">
		/// 	The request. 
		/// </param>
		/// <returns>
		/// 	A Task&lt;TokenIssueResponse&gt; 
		/// </returns>
		[Route("tokens")]
		[Route(Constants.CurrentApiVersion + "/tokens")]
        [Route(Constants.CurrentApiVersionLong + "/tokens")]
		[HttpPost]
		public async Task<TokenIssueResponse> IssueToken(TokenIssueRequest request)
		{
			// Login to CaaS
			if (_computeClient.WebApi.IsLoggedIn)
				_computeClient.WebApi.Logout();

			IAccount account = await _computeClient.LoginAsync(
				new NetworkCredential(
					request.Message.Credentials.UserName, 
					request.Message.Credentials.Password));

			// Get available clouds
			IEnumerable<DatacenterWithMaintenanceStatusType> dataCenters =
				await _computeClient.GetDataCentersWithMaintenanceStatuses();

			string loginToken = request.Message.Credentials.UserName + ":" + request.Message.Credentials.Password;

            string loginTokenEncoded = Convert.ToBase64String(Encoding.UTF8.GetBytes(loginToken));

			List<Endpoint> endPoints = new List<Endpoint>();
			endPoints.Add(new Endpoint
				{
					Url = ConfigurationHelpers.GetServerUrl(Request.RequestUri.Host, request.Message.TenantName), 
					Id = "AU1", // TODO: Map to cloud id?
                    InternalUrl = ConfigurationHelpers.GetServerUrl(Request.RequestUri.Host, request.Message.TenantName), 
                    PublicUrl = ConfigurationHelpers.GetServerUrl(Request.RequestUri.Host, request.Message.TenantName), 
					Region = "RegionOne" 
				});
			foreach (DatacenterWithMaintenanceStatusType dataCenter in dataCenters)
			{
				endPoints.Add(new Endpoint
				{
					Url = ConfigurationHelpers.GetServerUrl(Request.RequestUri.Host, request.Message.TenantName), 
					Id = dataCenter.location, // TODO: Map to cloud id?
                    InternalUrl = ConfigurationHelpers.GetServerUrl(Request.RequestUri.Host, request.Message.TenantName), 
                    PublicUrl = ConfigurationHelpers.GetServerUrl(Request.RequestUri.Host, request.Message.TenantName), 
					Region = "Dimension Data " + dataCenter.displayName 
				});
			}

		TokenIssueResponse response = new TokenIssueResponse
		    {
			    AccessToken = new AccessToken
			    {
					Token = new Token(loginTokenEncoded), 
					Catalog = new[]
					{
						new ServiceCatalogEntry
						{
							Endpoints = endPoints.ToArray(), 
							EndpointsLinks = new[]
                            {
                                ConfigurationHelpers.GetServerUrl(Request.RequestUri.Host, request.Message.TenantName)
                            }, 
							Name = "nova", 
							Type = EndpointType.compute
						}, 
                        new ServiceCatalogEntry
						{
							Endpoints = endPoints.ToArray(), 
							EndpointsLinks = new[]
                            {
                                ConfigurationHelpers.GetServerUrl(Request.RequestUri.Host, request.Message.TenantName)
                            }, 
							Name = "keystone", 
							Type = EndpointType.identity
						}, 
						new ServiceCatalogEntry
						{
							Endpoints = new[]
							{
								new Endpoint
								{
									Id = "1", 
									InternalUrl = ConfigurationHelpers.GetNetworkUrl(Request.RequestUri.Host), 
									PublicUrl = ConfigurationHelpers.GetNetworkUrl(Request.RequestUri.Host), 
									Region = "RegionOne", // TODO : Map to region
									Url = ConfigurationHelpers.GetNetworkUrl(Request.RequestUri.Host), 
								}
							}, 
							EndpointsLinks = new[]
                            {
                                ConfigurationHelpers.GetNetworkUrl(Request.RequestUri.Host)
                            }, 
							Name = "neutron", 
							Type = EndpointType.network
						}
					}, 
					User = new User
					{
						Id = Guid.NewGuid().ToString(), 
						Name = account.FullName, 
						Roles = new User.Role[] { }, 
						RolesLinks = new string[] { }, 
						UserName = request.Message.Credentials.UserName
					}
			    }
		    };
            return response;
	    }
	}
}
