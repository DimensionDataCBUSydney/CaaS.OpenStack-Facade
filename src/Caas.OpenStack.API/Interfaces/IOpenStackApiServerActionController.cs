using System.Net.Http;
using System.Threading.Tasks;
using Caas.OpenStack.API.Models.server;

namespace Caas.OpenStack.API.Interfaces
{
	public interface IOpenStackApiServerActionController
	{
		/// <summary>	Performs the server action. </summary>
		/// <param name="request">  	The request. </param>
		/// <param name="tenant_id">	Identifier for the tenant. </param>
		/// <param name="server_id">	Identifier for the server. </param>
		/// <returns>	A Task&lt;HttpResponseMessage&gt; </returns>
		Task<HttpResponseMessage> PerformServerAction(ServerActionRequest request, string tenant_id, string server_id);
	}
}
