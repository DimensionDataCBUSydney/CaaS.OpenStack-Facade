using System;
using System.Collections.Generic;
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

		[Route("{tenant}/images")]
		public async Task<BaseServerImageListResponse> GetServerImages(string tenant)
		{
			var remoteImageCollection = await _computeClient.GetImages("AU1");
			List<BaseServerImage> images = new List<BaseServerImage>();

			foreach (var image in remoteImageCollection)
			{
				images.Add(
					new BaseServerImage()
					{
						Id = image.id,
						Links = new[]
						{
							new RestLink(UrlGenerator.GetImageUri(tenant, image.id), RestLink.Self) 
						},
						Name = image.name
					});
			}

			return new BaseServerImageListResponse()
			{
				Images = images.ToArray()
			};
		}

		[Route("{tenant}/images/detail")]
		public async Task<ServerImageListResponse> GetServerImagesDetailed(string tenant)
		{
			var remoteImageCollection = await _computeClient.GetImages("AU1");
			List<Models.image.ServerImage> images = new List<Models.image.ServerImage>();

			foreach (var image in remoteImageCollection)
			{
				images.Add(
					new Models.image.ServerImage()
					{
						Id = image.id,
						CreatedDate = image.deployedTime.ToString("s"),
						Links = new RestLink[]
						{
							new RestLink(UrlGenerator.GetImageUri(tenant, image.id), RestLink.Self) 
						},
						MinDisk = 1, // No equivalent?
						MinRam = image.machineSpecification.memoryMb,
						Name = image.name,
						UpdatedDate = image.deployedTime.ToString("s")
					});
			}

			return new ServerImageListResponse()
			{
				Images = images.ToArray()
			};
		}

		[Route("{tenant}/images/{image}")]
	    public async Task<ServerImageResponse> GetServerImage(string tenant, string image)
		{
			var images = await _computeClient.GetImages("AU1");
			var selectedImage = images.First(i => i.id == image);
			
			if (selectedImage == null)
				throw new HttpResponseException(HttpStatusCode.BadRequest);

			return new ServerImageResponse()
			{
				Image = new Models.image.ServerImage()
				{
					Id = selectedImage.id,
					CreatedDate = selectedImage.deployedTime.ToString("s"),
					Links = new[]
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
