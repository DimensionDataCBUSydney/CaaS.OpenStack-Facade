using System.Web.Http;
using Caas.OpenStack.API.Models.api;

namespace Caas.OpenStack.API.Controllers
{
	public class BaseController : ApiController
	{
		[Route("")]
		public ApiVersionList GetAvailableApiVersions()
		{
			return new ApiVersionList(ConfigurationHelpers.GetBaseUrl());
		}
	}
}
