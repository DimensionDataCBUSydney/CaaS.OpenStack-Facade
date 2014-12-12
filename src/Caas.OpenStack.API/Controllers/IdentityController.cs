using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.UI.WebControls;
using Caas.OpenStack.API.Models.identity;
using Caas.OpenStack.API.Models.serviceCatalog;
using DD.CBU.Compute.Api.Client.Interfaces;
using DD.CBU.Compute.Api.Contracts.Directory;

namespace Caas.OpenStack.API.Controllers
{
	public class IdentityController : ApiController
	{
		private IComputeApiClient _computeClient;

		/// <summary>
		/// Initializes a new instance of the <see cref="ServerController"/> class.
		/// </summary>
		/// <param name="apiClient">The API client.</param>
		public IdentityController(Func<Uri, IComputeApiClient> apiClient)
		{
			_computeClient = apiClient(ConfigurationHelpers.GetApiUri());
		}

		[Route("tokens")]
		[Route(Constants.CurrentApiVersion + "/tokens")]
        [Route(Constants.CurrentApiVersionLong + "/tokens")]
		[HttpPost]
		public async Task<TokenIssueResponse> IssueToken(TokenIssueRequest request)
		{
			// Login to CaaS
			IAccount account = await _computeClient.LoginAsync(
				new NetworkCredential(
					request.Message.Credentials.UserName,
					request.Message.Credentials.Password));

			// Get available clouds
			IEnumerable<DatacenterWithMaintenanceStatusType> dataCenters =
				await _computeClient.GetDataCentersWithMaintenanceStatuses();

			string loginToken = request.Message.Credentials.UserName + ":" + request.Message.Credentials.Password;

            byte[] buffer = new byte[loginToken.Length];
            string loginTokenEncoded = Convert.ToBase64String(Encoding.UTF8.GetBytes(loginToken));

			List<Endpoint> endPoints = new List<Endpoint>();
			foreach (var dataCenter in dataCenters)
			{
				endPoints.Add(new Endpoint()
				{
					Url = ConfigurationHelpers.GetTenantUrl(request.Message.TenantName),
					Id = dataCenter.location, // TODO: Map to cloud id?
					InternalURL = ConfigurationHelpers.GetTenantUrl(request.Message.TenantName),
					PublicURL = ConfigurationHelpers.GetTenantUrl(request.Message.TenantName),
					Region = "Dimension Data " + dataCenter.displayName 
				});
			}

		TokenIssueResponse response = new TokenIssueResponse()
		    {
			    AccessToken = new AccessToken()
			    {
					Token = new Token(request.Message.TenantName, request.Message.TenantName, loginTokenEncoded),
					Catalog = new ServiceCatalogEntry[]
					{
						new ServiceCatalogEntry()
						{
							Endpoints = endPoints.ToArray(),
							EndpointsLinks = new string[]
                            {
                                ConfigurationHelpers.GetTenantUrl(request.Message.TenantName)
                            },
							Name = "nova",
							Type = EndpointType.compute
						},
                        new ServiceCatalogEntry()
						{
							Endpoints = endPoints.ToArray(),
							EndpointsLinks = new string[]
                            {
                                ConfigurationHelpers.GetTenantUrl(request.Message.TenantName)
                            },
							Name = "keystone",
							Type = EndpointType.identity
						}
					},
					User = new User()
					{
						Id = Guid.NewGuid().ToString(),
						Name = account.FullName,
						Roles = new User.Role[] { },
						RolesLinks = new string[]{},
						UserName = request.Message.Credentials.UserName
					}
			    }
		    };
            return response;
	    }
	}
}
