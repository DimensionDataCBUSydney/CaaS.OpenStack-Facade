// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServerActionController.cs" company="">
//   
// </copyright>
// <summary>
//   A controller for handling server actions.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Caas.OpenStack.API.Interfaces;
using Caas.OpenStack.API.Models.server;
using Caas.OpenStack.API.UriFactories;
using DD.CBU.Compute.Api.Client.Interfaces;
using DD.CBU.Compute.Api.Contracts.Server;

namespace Caas.OpenStack.API.Controllers
{
    /// <summary>	A controller for handling server actions. </summary>
    /// <remarks>	Anthony, 4/13/2015. </remarks>
    /// <seealso cref="T:System.Web.Http.ApiController"/>
	[Authorize]
	[RoutePrefix(Constants.ServerPrefix)]
    public class ServerActionController : ApiController, IOpenStackApiServerActionController
    {
		/// <summary>	The compute client. </summary>
		private readonly IComputeApiClient _computeClient;

		/// <summary>
		/// Initialises a new instance of the <see cref="ServerActionController"/> class. 
		/// 	Initializes a new instance of the <see cref="ServerController"/> class. 
		/// </summary>
		/// <remarks>
		/// 	Anthony, 4/13/2015. 
		/// </remarks>
		/// <param name="apiClient">
		/// 	The API client. 
		/// </param>
		public ServerActionController(Func<Uri, IComputeApiClient> apiClient)
        {
            _computeClient = apiClient(ConfigurationHelpers.GetApiUri());
        }

		/// <summary>
		/// 	Performs the server action. 
		/// </summary>
		/// <remarks>
		/// 	Anthony, 4/13/2015. 
		/// </remarks>
		/// <param name="request">
		/// 	The request. 
		/// </param>
		/// <param name="tenantId">
		/// 	Identifier for the tenant. 
		/// </param>
		/// <param name="serverId">
		/// 	Identifier for the server. 
		/// </param>
		/// <returns>
		/// 	A HttpResponseMessage 
		/// </returns>
		[Route("{tenantId}/servers/{server_id}/action")]
		[HttpPost]
		public async Task<HttpResponseMessage> PerformServerAction([FromBody]ServerActionRequest request, [FromUri] string tenantId, [FromUri] string serverId)
		{
			if (request.CreateImage != null)
			{
				// Get base image
				IEnumerable<ServerWithBackupType> servers = await _computeClient.GetDeployedServers();
				if (servers == null)
					return new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);

				ServerWithBackupType server = servers.First(s => s.id == serverId);
				if (server == null)
					return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
				HttpResponseMessage response = new HttpResponseMessage(System.Net.HttpStatusCode.Accepted);
				response.Headers.Add("Location", ImageUriFactory.GetImageUri(Request.RequestUri.Host, tenantId, server.sourceImageId));

				return response;
			}

			if (request.ChangePassword != null)
			{
				return new HttpResponseMessage(System.Net.HttpStatusCode.Accepted);
			}

			return new HttpResponseMessage(System.Net.HttpStatusCode.Accepted);
		}
    }
}