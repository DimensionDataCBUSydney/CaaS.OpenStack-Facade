using System;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Client.Interfaces;
using Microsoft.Owin;

namespace Caas.OpenStack.API.Middleware
{
	public class CaaSAuthenticationMiddleWare
		: OwinMiddleware
	{
		private IComputeApiClient _apiClient;

		public CaaSAuthenticationMiddleWare(OwinMiddleware next, Func<Uri, IComputeApiClient> apiClient)
			: base(next)
		{
			_apiClient = apiClient(ConfigurationHelpers.GetApiUri());
		}

		public async override Task Invoke(IOwinContext context)
		{
			var request = context.Request;

			var header = request.Headers["Authorization"];

			var authtoken = request.Headers["X-Auth-Token"];
			if (!String.IsNullOrWhiteSpace(authtoken))
			{
				string token = Encoding.UTF8.GetString(Convert.FromBase64String(authtoken));
				var parts = token.Split(':');

				string userName = parts[0];
				string password = parts[1];

				if (_apiClient.Account != null)
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

			if (!String.IsNullOrWhiteSpace(header))
			{
				var authHeader = System.Net.Http.Headers
								   .AuthenticationHeaderValue.Parse(header);

				if ("Basic".Equals(authHeader.Scheme,
										 StringComparison.OrdinalIgnoreCase))
				{
					string parameter = Encoding.UTF8.GetString(
										  Convert.FromBase64String(
												authHeader.Parameter));
					var parts = parameter.Split(':');

					string userName = parts[0];
					string password = parts[1];

					if (_apiClient.Account != null)
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