using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using Caas.OpenStack.API.Models;
using DD.CBU.Compute.Api.Client.Interfaces;

namespace Caas.OpenStack.API.Controllers
{
	[Authorize]
	[RoutePrefix(Constants.CurrentApiVersion)]
    public class ImageController : ApiController
    {
		private IComputeApiClient _computeClient;

		public ImageController(Func<Uri, IComputeApiClient> apiClient)
		{
			_computeClient = apiClient(ConfigurationHelpers.GetApiUri());
		}

	    public static string GetImageUri(string tenantId, string imageId)
	    {
		    return String.Format(
			    "{0}{1}/{2}/images/{3}",
			    ConfigurationHelpers.GetBaseUrl(),
				Constants.CurrentApiVersion,
				tenantId,
				imageId
			    );
	    }

		[Route("{tenant_id}​/images/​{image_id}​")]
	    public async Task<Models.image.ServerImageResponse> GetImage(string tenant_id, string image_id)
	    {
			var images = await _computeClient.GetImages("AU1");
			var selectedImage = images.First(image => image.id == image_id);

			if (selectedImage == null)
				throw new HttpResponseException(HttpStatusCode.BadRequest);

			return new Models.image.ServerImageResponse()
			{
				Image = new Models.image.ServerImage()
				{
					Id = selectedImage.id,
					CreatedDate = selectedImage.deployedTime.ToString("s"),
					Links = new RestLink[]
					{
						new RestLink(GetImageUri(tenant_id, image_id),RestLink.Self) 
					},
					MinDisk = 1 ,// No equivalent?
					MinRam = selectedImage.machineSpecification.memoryMb,
					Name = selectedImage.name,
					UpdatedDate = selectedImage.deployedTime.ToString("s")
				}
			};
	    }
    }
}
