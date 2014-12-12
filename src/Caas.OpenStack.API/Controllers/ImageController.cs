using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using Caas.OpenStack.API.Models;
using Caas.OpenStack.API.Models.image;
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

		[Route("{tenant}/images/{image}")]
	    public async Task<ServerImageResponse> GetServerImage(string tenant, string image)
		{
			var images = await _computeClient.GetImages("AU1");
			var selectedImage = images.First(i => i.id == image);
			
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
						new RestLink(UrlGenerator.GetImageUri(tenant, image), RestLink.Self) 
					},
					MinDisk = 1, // No equivalent?
					MinRam = selectedImage.machineSpecification.memoryMb,
					Name = selectedImage.name,
					UpdatedDate = selectedImage.deployedTime.ToString("s")
				}
			};
		}
    }
}
