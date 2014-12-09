using System;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Autofac;
using Caas.OpenStack.API.Middleware;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Client.Interfaces;
using Microsoft.Owin;
using Microsoft.Owin.Logging;
using Owin;
using System.Web;
using System.IO;
using Microsoft.Owin.Extensions;
[assembly: OwinStartup(typeof(Caas.OpenStack.API.Startup))]

namespace Caas.OpenStack.API
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			ContainerBuilder builder = new ContainerBuilder();

			// Add a singleton of the API client to the pipeline.
			builder.RegisterType<ComputeApiClient>()
				.As<IComputeApiClient>()
				.InstancePerRequest();
			builder.Register<Func<Uri, IComputeApiClient>>(c =>
				{
					var context = c.Resolve<IComponentContext>();
					return uri => context.Resolve<IComputeApiClient>(new TypedParameter(typeof(Uri), uri));
				});

			builder.RegisterType<CaaSAuthenticationMiddleWare>()
				.InstancePerRequest();

			ILifetimeScope scope = builder.Build();

			var config = new HttpConfiguration();

			// Map our controller routes.
			config.MapHttpAttributeRoutes();

			// Setup WebApi and Autofac with OWIN support
			app.UseAutofacMiddleware(scope);

			// Use a custom authentication module
			app.UseAutofacWebApi(config);
		}
	}
}