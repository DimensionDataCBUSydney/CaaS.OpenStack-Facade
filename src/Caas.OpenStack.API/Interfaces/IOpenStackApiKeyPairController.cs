// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IOpenStackApiKeyPairController.cs" company="">
//   
// </copyright>
// <summary>
//   Interface for open stack API key pair controller.
//   GET/v2/​{tenant_id}​/os-keypairs List keypairs
//   Lists keypairs that are associated with the account.
//   detail
//   POST/v2/​{tenant_id}​/os-keypairs Create or import keypair
//   Generates or imports a keypair.
//   detail
//   DELETE/v2/​{tenant_id}​/os-keypairs/​{keypair_name}​Delete keypair
//   Deletes a keypair.
//   detail
//   GET/v2/​{tenant_id}​/os-keypairs/​{keypair_name}​Show keypair information
//   Shows a keypair associated with the account.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System.Threading.Tasks;
using Caas.OpenStack.API.Models.keypair;

namespace Caas.OpenStack.API.Interfaces
{
	/// <summary>	Interface for open stack API key pair controller.
	/// 			GET/v2/​{tenant_id}​/os-keypairs List keypairs
	/// Lists keypairs that are associated with the account.
	///
	///  detail
	/// POST/v2/​{tenant_id}​/os-keypairs Create or import keypair
	/// Generates or imports a keypair.
	///
	///  detail
	/// DELETE/v2/​{tenant_id}​/os-keypairs/​{keypair_name}​Delete keypair
	/// Deletes a keypair.
	///
	///  detail
	/// GET/v2/​{tenant_id}​/os-keypairs/​{keypair_name}​Show keypair information
	/// Shows a keypair associated with the account. </summary>
	/// <remarks>	Anthony, 4/15/2015. </remarks>
	public interface IOpenStackApiKeyPairController
	{
		/// <summary>
		/// 	Gets key pairs
		/// 			GET/v2/​{tenant_id}​/os-keypairs. 
		/// </summary>
		/// <param name="tenantId">
		/// The tenant Id.
		/// </param>
		/// <returns>
		/// 	The key pairs. 
		/// </returns>
		Task<KeyPairCollectionResponse> GetKeyPairs(string tenantId);

		/// <summary>
		/// 	Creates key pair. 
		/// 			POST/v2/​{tenant_id}​/os-keypairs
		/// </summary>
		/// <param name="tenantId">
		/// The tenant Id.
		/// </param>
		/// <param name="request">
		/// 	The request. 
		/// </param>
		/// <returns>
		/// 	The new key pair. 
		/// </returns>
		Task<KeyPairDetailResponse> CreateKeyPair(string tenantId, KeyPairCreateRequest request);

		/// <summary>
		/// 	Deletes the key pair described by keypairName
		/// 			DELETE/v2/​{tenant_id}​/os-keypairs/​{keypair_name}. 
		/// </summary>
		/// <param name="tenantId">
		/// The tenant Id.
		/// </param>
		/// <param name="keypairName">
		/// 	Name of the key pair. 
		/// </param>
		/// <returns>
		/// 	A Task. 
		/// </returns>
		Task DeleteKeyPair(string tenantId, string keypairName);

		/// <summary>
		/// 	Updates the key pair described by keypairName
		/// 			GET/v2/​{tenant_id}​/os-keypairs/​{keypair_name}. 
		/// </summary>
		/// <param name="tenantId">
		/// The tenant Id.
		/// </param>
		/// <param name="keypairName">
		/// 	Name of the key pair. 
		/// </param>
		/// <returns>
		/// 	A KeyPairDetailResponse; 
		/// </returns>
		Task<KeyPairDetailResponse> GetKeyPair(string tenantId, string keypairName);
	}
}
