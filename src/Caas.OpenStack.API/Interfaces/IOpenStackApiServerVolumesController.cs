using Caas.OpenStack.API.Models.server;

namespace Caas.OpenStack.API.Interfaces
{
	/// <summary>	Interface for open stack API server volumes controller. </summary>
	/// <remarks>	Anthony, 4/20/2015. </remarks>
	public interface IOpenStackApiServerVolumesController
	{
		/// <summary>	List volumes.
		/// 			GET/v1.1/​{tenant_id}​/os-volumes </summary>
		/// <param name="tenantId">	Identifier for the tenant. </param>
		/// <returns>	A list of. </returns>
		ServerVolumeCollectionResponse ListVolumes(string tenantId);

		/// <summary>	List volumes details. 
		/// 			GET/v1.1/​{tenant_id}​/os-volumes/detail</summary>
		/// <param name="tenantId">	Identifier for the tenant. </param>
		/// <returns>	A list of. </returns>
		ServerVolumeCollectionResponse ListVolumesDetails(string tenantId);

		/// <summary>	Creates a volume.
		/// 			POST/v1.1/​{tenant_id}​/os-volumes/​{volume_id}​ </summary>
		/// <param name="tenantId">	Identifier for the tenant. </param>
		/// <param name="request"> 	The request. </param>
		/// <returns>	The new volume. </returns>
		ServerVolumeResponse CreateVolume(string tenantId, ServerVolumeCreationRequest request);

		/// <summary>	Gets a volume. 
		/// 			GET/v1.1/​{tenant_id}​/os-volumes/​{volume_id}​</summary>
		/// <param name="tenantId">	Identifier for the tenant. </param>
		/// <param name="volumeId">	Identifier for the volume. </param>
		/// <returns>	The volume. </returns>
		ServerVolumeResponse GetVolume(string tenantId, string volumeId);

		/// <summary>	Deletes the volume. 
		/// 			DELETE/v1.1/​{tenant_id}​/os-volumes/​{volume_id}​</summary>
		/// <param name="tenantId">	Identifier for the tenant. </param>
		/// <param name="volumeId">	Identifier for the volume. </param>
		void DeleteVolume (string tenantId, string volumeId);
	}
}
