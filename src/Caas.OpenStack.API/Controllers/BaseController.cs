// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseController.cs" company="">
//   
// </copyright>
// <summary>
//   A controller for handling bases.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System.Web.Http;
using Caas.OpenStack.API.Models.api;

namespace Caas.OpenStack.API.Controllers
{
	/// <summary>	A controller for handling bases. </summary>
	/// <remarks>	Anthony, 4/13/2015. </remarks>
	/// <seealso cref="T:System.Web.Http.ApiController"/>
	public class BaseController : ApiController
	{
		/// <summary>	Gets available API versions. </summary>
		/// <remarks>	Anthony, 4/13/2015. </remarks>
		/// <returns>	The available API versions. </returns>
		[Route("")]
		public ApiVersionList GetAvailableApiVersions()
		{
			return new ApiVersionList(ConfigurationHelpers.GetBaseUrl());
		}
	}
}
