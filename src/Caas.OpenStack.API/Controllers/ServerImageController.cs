using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using Caas.OpenStack.API.Models;
using Caas.OpenStack.API.Models.image;
using Caas.OpenStack.API.UriFactories;
using DD.CBU.Compute.Api.Client.Interfaces;

namespace Caas.OpenStack.API.Controllers
{
    /// <summary>	A controller for handling images. </summary>
    /// <remarks>	Anthony, 4/13/2015. </remarks>
    /// <seealso cref="T:System.Web.Http.ApiController"/>
	[Authorize]
	[RoutePrefix(Constants.ServerPrefix)]
    public class ServerImageController : ApiController
    {
	    /// <summary>	The compute client. </summary>
		private readonly IComputeApiClient _computeClient;

		/// <summary> Initializes a new instance of the ImageController
		/// 	class. </summary>
		/// <remarks>	Anthony, 4/13/2015. </remarks>
		/// <param name="apiClient">	The API client. </param>
		public ServerImageController(Func<Uri, IComputeApiClient> apiClient)
		{
			_computeClient = apiClient(ConfigurationHelpers.GetApiUri());
		}

		/// <summary>	Gets server images. </summary>
		/// <remarks>	Anthony, 4/13/2015. </remarks>
		/// <param name="tenant">	The tenant. </param>
		/// <returns>	The server images. </returns>
		[Route("{tenant}/images")]
		public async Task<BaseServerImageListResponse> GetServerImages(string tenant)
		{
			var remoteImageCollection = await _computeClient.GetImages(String.Empty, String.Empty, String.Empty, String.Empty, String.Empty);

			return new BaseServerImageListResponse
			{
				Images = remoteImageCollection.Select(image => new BaseServerImage
				{
					Id = image.id, Links = new[]
					{
						new RestLink(ImageUriFactory.GetImageUri(tenant, image.id), RestLink.Self)
					},
					Name = image.name
				}).ToArray()
			};
		}

		/// <summary>	Gets server images detailed. </summary>
		/// <remarks>	Anthony, 4/13/2015. </remarks>
		/// <param name="tenant">	The tenant. </param>
		/// <returns>	The server images detailed. </returns>
		[Route("{tenant}/images/detail")]
		public async Task<ServerImageListResponse> GetServerImagesDetailed(string tenant)
		{
			var remoteImageCollection = await _computeClient.GetImages(String.Empty, String.Empty, String.Empty, String.Empty, String.Empty);

			return new ServerImageListResponse
			{
				Images = remoteImageCollection.Select(image => new ServerImage
				{
					Id = image.id, 
					CreatedDate = DateTime.Parse(image.created).ToString("s"), 
					Links = new[]
					{
						new RestLink(ImageUriFactory.GetImageUri(tenant, image.id), RestLink.Self)
					},
					MinDisk = 1, // No equivalent?
					MinRam = 1024, // No equivalent 
					Name = image.name,
					UpdatedDate = DateTime.Parse(image.created).ToString("s")
				}).ToArray()
			};
		}

	    /// <summary>	Gets server image. </summary>
	    /// <remarks>	Anthony, 4/13/2015. </remarks>
	    /// <exception cref="HttpResponseException">	Thrown when a HTTP Response error condition
	    /// 											occurs. </exception>
	    /// <param name="tenant">	The tenant. </param>
	    /// <param name="image"> 	The image. </param>
	    /// <returns>	The server image. </returns>
		[Route("{tenant}/images/{image}")]
	    public async Task<ServerImageResponse> GetServerImage(string tenant, string image)
		{
			var images = await _computeClient.GetImages(String.Empty, String.Empty, String.Empty, String.Empty, String.Empty);
			var selectedImage = images.First(i => i.id == image);
			
			if (selectedImage == null)
				throw new HttpResponseException(HttpStatusCode.BadRequest);

			return new ServerImageResponse
			{
				Image = new ServerImage
				{
					Id = selectedImage.id,
					CreatedDate = DateTime.Parse(selectedImage.created).ToString("s"),
					Links = new[]
					{
						new RestLink(ImageUriFactory.GetImageUri(tenant, image), RestLink.Self) 
					},
					MinDisk = 1, // No equivalent?
					MinRam = 1024, // No  equivalent
					Name = selectedImage.name,
					UpdatedDate = DateTime.Parse(selectedImage.created).ToString("s")
				}
			};
		}
    }
}
