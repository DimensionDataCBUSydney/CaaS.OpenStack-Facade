// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServerTranslators.cs" company="">
//   
// </copyright>
// <summary>
//   Translating CaaS server models to OpenStack..
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System;
using System.Net.Http;
using Caas.OpenStack.API.Models;
using Caas.OpenStack.API.Models.server;
using Caas.OpenStack.API.UriFactories;
using DD.CBU.Compute.Api.Contracts.Server;

namespace Caas.OpenStack.API.Translators
{
	/// <summary> Translating CaaS server models to OpenStack.. </summary>
	/// <remarks>	Anthony, 4/13/2015. </remarks>
	public static class ServerTranslators
	{
		/// <summary>
		/// 	Convert a CaaS Server type to an OpenStack server type. 
		/// </summary>
		/// <remarks>
		/// 	Anthony, 4/13/2015. 
		/// </remarks>
		/// <param name="request">
		/// 	The request to act on. 
		/// </param>
		/// <param name="server">
		/// 	The server. 
		/// </param>
		/// <param name="tenantId">
		/// 	The tenantId. 
		/// </param>
		/// <returns>
		/// 	A BaseServer. 
		/// </returns>
		public static BaseServer CaaSServerToServer(this HttpRequestMessage request, ServerWithBackupType server, string tenantId)
		{
			return new BaseServer
			{
				Id = Guid.Parse(server.id), 
				Name = server.name, 
				Links = new[]
					{
						new RestLink(ServerUriFactory.GetServerUri(request.RequestUri.Host, tenantId, server.id), RestLink.Self) 
					}
			};
		}

		/// <summary>
		/// 	Convert a CaaS Server type to an OpenStack server type. (detailed). 
		/// </summary>
		/// <remarks>
		/// 	Anthony, 4/13/2015. 
		/// </remarks>
		/// <param name="request">
		/// 	The request to act on. 
		/// </param>
		/// <param name="server">
		/// 	The server. 
		/// </param>
		/// <param name="tenantId">
		/// 	The tenantId. 
		/// </param>
		/// <returns>
		/// 	A ServerDetail. 
		/// </returns>
		public static ServerDetail CaaSServerToServerDetail(this HttpRequestMessage request, ServerWithBackupType server, string tenantId)
		{
			return new ServerDetail
			{
				AccessIPv4 = server.privateIp, 
				AccessIPv6 = string.Empty, // IPv6 not supported at present- MCP2.0 API will
				CreatedDate = server.created.ToString("s"), 
				HostId = server.name, 
				Id = Guid.Parse(server.id), 
				Image = new Models.image.ServerImage
				{
					Id = server.sourceImageId, 
					Links = new[]
						{
							new RestLink(
								ImageUriFactory.GetImageUri(request.RequestUri.Host, tenantId, server.sourceImageId), 
								RestLink.Bookmark
								)
						}
				}, 
				IpAddressCollection = new IpAddressCollection
				{
					PrivateAddresses = new[]
						{
							new IpAddress(server.privateIp)
						}, 
					PublicAddresses = new[]
 						{
 							new IpAddress(server.publicIp)
 						}
				}, 
				Flavor = new Flavor(), 
				Name = server.name, 
				Links = new[]
					{
						new RestLink(ServerUriFactory.GetServerUri(request.RequestUri.Host, tenantId, server.id), RestLink.Self) 
					}, 
				UserId = request.GetRequestContext().Principal.Identity.Name, 
				TenantId = tenantId, 
				Metadata = new
				{
					MyServerName = server.name
				}, // TODO: decide what metadata should be shown.
				Status = ServerStatus.Active // TODO : Map CaaS status.
			};
		}
	}
}