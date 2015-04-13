using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Caas.OpenStack.API.Models.server;
using DD.CBU.Compute.Api.Client.Interfaces;

namespace Caas.OpenStack.API.Controllers
{
    public class ServerActionController : ApiController
    {
		/// <summary>	The compute client. </summary>
		private IComputeApiClient _computeClient;

		/// <summary>	Initializes a new instance of the <see cref="ServerController"/> class. </summary>
		/// <remarks>	Anthony, 4/13/2015. </remarks>
		/// <param name="apiClient">	The API client. </param>
		public ServerActionController(Func<Uri, IComputeApiClient> apiClient)
        {
            _computeClient = apiClient(ConfigurationHelpers.GetApiUri());
        }

		[System.Web.Mvc.Route("{tenant_id}/servers/{server_id}/action")]
		[System.Web.Http.HttpPost]
		public async Task<HttpResponseMessage> PerformServerAction([FromBody]ServerActionRequest request, [FromUri] string tenant_id, [FromUri] string server_id)
		{
			if (request.CreateImage != null)
			{
				// Get base image
				var servers = await _computeClient.GetDeployedServers();
				if (servers == null)
					return new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);

				var server = servers.First(s => s.id == server_id);
				if (server == null)
					return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
				HttpResponseMessage response = new HttpResponseMessage(System.Net.HttpStatusCode.Accepted);
				response.Headers.Add("Location", UrlGenerator.GetImageUri(Request.RequestUri.Host, tenant_id, server.sourceImageId));

				return response;
			}
			if (request.ChangePassword != null)
			{
				return new HttpResponseMessage(System.Net.HttpStatusCode.Accepted);
			}
			else
			{
				return new HttpResponseMessage(System.Net.HttpStatusCode.Accepted);
			}
		}
    }
}