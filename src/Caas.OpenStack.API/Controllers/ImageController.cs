using System;
using System.Web.Http;
using ServerImage = Caas.OpenStack.API.Models.image.ServerImage;

namespace Caas.OpenStack.API.Controllers
{
	[Authorize]
	[RoutePrefix(Constants.CurrentApiVersion)]
    public class ImageController : ApiController
    {
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
	    public Models.image.ServerImage GetImage(string tenant_id, string image_id)
	    {
			// TODO: Implementation.
			return new Models.image.ServerImage();
	    }
    }
}
