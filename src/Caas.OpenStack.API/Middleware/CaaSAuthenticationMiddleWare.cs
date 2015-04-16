// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CaaSAuthenticationMiddleWare.cs" company="">
//   
// </copyright>
// <summary>
//   Authentication middleware to take a token and decrypt into username/password pair..
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System;
using System.Net;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DD.CBU.Compute.Api.Client.Interfaces;
using Microsoft.Owin;

namespace Caas.OpenStack.API.Middleware
{
	/// <summary>	Authentication middleware to take a token and decrypt into username/password pair.. </summary>
	/// <remarks>	Anthony, 4/13/2015. </remarks>
	/// <seealso cref="T:Microsoft.Owin.OwinMiddleware"/>
	public class CaaSAuthenticationMiddleWare
		: OwinMiddleware
	{
		/// <summary>	The API client. </summary>
		private readonly IComputeApiClient _apiClient;

		/// <summary>
		/// Initialises a new instance of the <see cref="CaaSAuthenticationMiddleWare"/> class. 
		/// Initializes a new instance of the CaaSAuthenticationMiddleWare class. 
		/// </summary>
		/// <remarks>
		/// 	Anthony, 4/13/2015. 
		/// </remarks>
		/// <param name="next">
		/// 			The next. 
		/// </param>
		/// <param name="apiClient">
		/// 	The API client. 
		/// </param>
		public CaaSAuthenticationMiddleWare(OwinMiddleware next, Func<Uri, IComputeApiClient> apiClient)
			: base(next)
		{
			_apiClient = apiClient(ConfigurationHelpers.GetApiUri());
		}

		/// <summary>
		/// 	Process an individual request. 
		/// </summary>
		/// <remarks>
		/// 	Anthony, 4/13/2015. 
		/// </remarks>
		/// <param name="context">
		/// 	The OWIN context. 
		/// </param>
		/// <returns>
		/// 	A Task. 
		/// </returns>
		/// <seealso cref="M:Microsoft.Owin.OwinMiddleware.Invoke(IOwinContext)"/>
		public async override Task Invoke(IOwinContext context)
		{
			IOwinRequest request = context.Request;

			string header = request.Headers["Authorization"];

            string authtoken = request.Headers["X-Auth-Token"];
            if (!string.IsNullOrWhiteSpace(authtoken))
            {
                string token = Encoding.UTF8.GetString(Convert.FromBase64String(authtoken));
                string[] parts = token.Split(':');

                string userName = parts[0];
                string password = parts[1];

                if (_apiClient.WebApi.IsLoggedIn)
                {
                    _apiClient.WebApi.Logout();
                }

                await _apiClient.LoginAsync(new NetworkCredential(userName, password));

                var claims = new[]
					{
						new Claim(ClaimTypes.Name, userName)
					};
                var identity = new ClaimsIdentity(claims, "Basic");

                request.User = new ClaimsPrincipal(identity);
            }

			if (!string.IsNullOrWhiteSpace(header))
			{
				AuthenticationHeaderValue authHeader = System.Net.Http.Headers
								   .AuthenticationHeaderValue.Parse(header);

				if ("Basic".Equals(authHeader.Scheme, 
										 StringComparison.OrdinalIgnoreCase))
				{
					string parameter = Encoding.UTF8.GetString(
										  Convert.FromBase64String(
												authHeader.Parameter));
					string[] parts = parameter.Split(':');

					string userName = parts[0];
					string password = parts[1];

					if (_apiClient.WebApi.IsLoggedIn)
					{
						_apiClient.WebApi.Logout();
					}

					await _apiClient.LoginAsync(new NetworkCredential(userName, password));

					var claims = new[]
					{
						new Claim(ClaimTypes.Name, userName)
					};
					var identity = new ClaimsIdentity(claims, "Basic");

					request.User = new ClaimsPrincipal(identity);
				}
			}

			await Next.Invoke(context);
		}
	}
}