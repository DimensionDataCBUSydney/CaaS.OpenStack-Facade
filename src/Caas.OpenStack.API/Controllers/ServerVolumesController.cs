using System;
using System.Collections.Generic;
using System.Web.Http;
using Caas.OpenStack.API.Interfaces;
using Caas.OpenStack.API.Models.server;
using DD.CBU.Compute.Api.Client.Interfaces;

namespace Caas.OpenStack.API.Controllers
{
	/// <summary>	A controller for handling server volumes. </summary>
	/// <remarks>	Anthony, 4/20/2015. </remarks>
	/// <seealso cref="T:System.Web.Http.ApiController"/>
	/// <seealso cref="T:Caas.OpenStack.API.Interfaces.IOpenStackApiServerVolumesController"/>
	[Authorize]
	[RoutePrefix(Constants.ServerPrefix)]
	public class ServerVolumesController : ApiController, IOpenStackApiServerVolumesController
	{
		/// <summary>	The compute client. </summary>
		private readonly IComputeApiClient _computeClient;

		/// <summary> Initialises a new instance of the <see cref="ServerController"/> class. Initializes a
		/// 	new instance of the <see cref="ServerController"/> class. </summary>
		/// <remarks>	Anthony, 4/20/2015. </remarks>
		/// <param name="apiClient">	The API client. </param>
		public ServerVolumesController(Func<Uri, IComputeApiClient> apiClient)
        {
            _computeClient = apiClient(ConfigurationHelpers.GetApiUri());
        }

		/// <summary>	List volumes. GET/v1.1/​{tenant_id}​/os-volumes. </summary>
		/// <remarks>	Anthony, 4/20/2015. </remarks>
		/// <param name="tenantId">	Identifier for the tenant. </param>
		/// <returns>	A list of. </returns>
		/// <seealso cref="M:Caas.OpenStack.API.Interfaces.IOpenStackApiServerVolumesController.ListVolumes(string)"/>
		[HttpGet]
		[Route("{tenantId}/os-volumes")]
		public ServerVolumeCollectionResponse ListVolumes(string tenantId)
		{
			return new ServerVolumeCollectionResponse
			{
				Volumes = new List<ServerVolume>
				{
					new ServerVolume
					{
						Id = "ECO",
						CreatedAt = DateTime.Today.ToString("s"), // TODO! 
 						DisplayName = "Economy",
						DisplayDescription = "Slow storage",
						Size = 100, // TODO : Calculate the total amount of this storage type.
						VolumeType = "ECO",
						AvailabilityZone = "AU1"
					}
				}
			};
		}

		/// <summary>	List volumes details. GET/v1.1/​{tenant_id}​/os-volumes/detail. </summary>
		/// <remarks>	Anthony, 4/20/2015. </remarks>
		/// <param name="tenantId">	Identifier for the tenant. </param>
		/// <returns>	A list of. </returns>
		/// <seealso cref="M:Caas.OpenStack.API.Interfaces.IOpenStackApiServerVolumesController.ListVolumesDetails(string)"/>
		[HttpGet]
		[Route("{tenantId}/os-volumes/detail")]
		public ServerVolumeCollectionResponse ListVolumesDetails(string tenantId)
		{
			return new ServerVolumeCollectionResponse
			{
				Volumes = new List<ServerVolume>
				{
					new ServerVolume
					{
						Id = "ECO",
						CreatedAt = DateTime.Today.ToString("s"), // TODO! 
 						DisplayName = "Economy",
						DisplayDescription = "Slow storage",
						Size = 100, // TODO : Calculate the total amount of this storage type.
						VolumeType = "ECO",
						AvailabilityZone = "AU1"
					}
				}
			};
		}

		/// <summary>	Creates a volume. POST/v1.1/​{tenant_id}​/os-volumes/​{volume_id}​. </summary>
		/// <remarks>	Anthony, 4/20/2015. </remarks>
		/// <param name="tenantId">	Identifier for the tenant. </param>
		/// <param name="request"> 	The request. </param>
		/// <returns>	The new volume. </returns>
		/// <seealso cref="M:Caas.OpenStack.API.Interfaces.IOpenStackApiServerVolumesController.CreateVolume(string,ServerVolumeCreationRequest)"/>
		[HttpPost]
		[Route("{tenantId}/os-volumes")]
		public ServerVolumeResponse CreateVolume(string tenantId, ServerVolumeCreationRequest request)
		{
			throw new NotImplementedException();
		}

		/// <summary>	Gets a volume. GET/v1.1/​{tenant_id}​/os-volumes/​{volume_id}​. </summary>
		/// <remarks>	Anthony, 4/20/2015. </remarks>
		/// <param name="tenantId">	Identifier for the tenant. </param>
		/// <param name="volumeId">	Identifier for the volume. </param>
		/// <returns>	The volume. </returns>
		/// <seealso cref="M:Caas.OpenStack.API.Interfaces.IOpenStackApiServerVolumesController.GetVolume(string,string)"/>
		[HttpGet]
		[Route("{tenantId}/os-volumes/{volumeId}")]
		public ServerVolumeResponse GetVolume(string tenantId, string volumeId)
		{
			throw new NotImplementedException();
		}

		/// <summary>	Deletes the volume. DELETE/v1.1/​{tenant_id}​/os-volumes/​{volume_id}​. </summary>
		/// <remarks>	Anthony, 4/20/2015. </remarks>
		/// <param name="tenantId">	Identifier for the tenant. </param>
		/// <param name="volumeId">	Identifier for the volume. </param>
		/// <seealso cref="M:Caas.OpenStack.API.Interfaces.IOpenStackApiServerVolumesController.DeleteVolume(string,string)"/>
		[HttpDelete]
		[Route("{tenantId}/os-volumes/{volumeId}")]
		public void DeleteVolume(string tenantId, string volumeId)
		{
			throw new NotImplementedException();
		}
	}
}