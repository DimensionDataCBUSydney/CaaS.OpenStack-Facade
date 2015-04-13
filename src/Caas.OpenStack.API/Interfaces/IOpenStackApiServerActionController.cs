using System.Net.Http;
using System.Threading.Tasks;
using Caas.OpenStack.API.Models.server;

namespace Caas.OpenStack.API.Interfaces
{
	/// <summary>	Interface for open stack API server action controller. </summary>
	/// <remarks>	Anthony, 4/13/2015. </remarks>
	public interface IOpenStackApiServerActionController
	{
		/// <summary>	Performs the server action. </summary>
		/// <param name="request">  	The request. </param>
		/// <param name="tenantId">	Identifier for the tenant. </param>
		/// <param name="serverId">	Identifier for the server. </param>
		/// <returns>	A Task&lt;HttpResponseMessage&gt; </returns>
		Task<HttpResponseMessage> PerformServerAction(ServerActionRequest request, string tenantId, string serverId);
	}
}
