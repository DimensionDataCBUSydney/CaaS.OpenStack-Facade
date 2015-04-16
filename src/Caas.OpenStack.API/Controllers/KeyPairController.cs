// --------------------------------------------------------------------------------------------------------------------
// <copyright file="KeyPairController.cs" company="">
//   
// </copyright>
// <summary>
//   A controller for handling key pairs.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System;
using System.Threading.Tasks;
using System.Web.Http;
using Caas.OpenStack.API.Interfaces;
using Caas.OpenStack.API.Models.keypair;

namespace Caas.OpenStack.API.Controllers
{
	/// <summary>	A controller for handling key pairs. </summary>
	/// <remarks>	Anthony, 4/15/2015. </remarks>
	/// <seealso cref="T:System.Web.Http.ApiController"/>
	/// <seealso cref="T:Caas.OpenStack.API.Interfaces.IOpenStackApiKeyPairController"/>
	[Authorize]
	[RoutePrefix(Constants.ServerPrefix)]
	public class KeyPairController : ApiController, IOpenStackApiKeyPairController
	{
		/// <summary>
		/// 	Gets key pairs GET/v2/​{tenant_id}​/os-keypairs. 
		/// </summary>
		/// <param name="tenantId">
		/// The tenant Id.
		/// </param>
		/// <remarks>
		/// 	Anthony, 4/15/2015. 
		/// </remarks>
		/// <returns>
		/// 	The key pairs. 
		/// </returns>
		/// <seealso cref="M:Caas.OpenStack.API.Interfaces.IOpenStackApiKeyPairController.GetKeyPairs()"/>
		[HttpGet]
		[Route("{tenantId}/os-keypairs")]
		public Task<KeyPairCollectionResponse> GetKeyPairs(string tenantId)
		{
			// CaaS doesn't have a construct like this, so return a nonsense key.
			return Task.FromResult(new KeyPairCollectionResponse
			{
				KeyPairs = new[]
				{
					new KeyPairDetailResponse
					{
						Key = new Keypair
						{
							Fingerprint = "15:b0:f8:b3:f9:48:63:71:cf:7b:5b:38:6d:44:2d:4a", 
							Name = "keypair-601a2305-4f25-41ed-89c6-2a966fc8027a", 
							PublicKey =
								"ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAAAgQC+Eo/RZRngaGTkFs7I62ZjsIlO79KklKbMXi8F+KITD4bVQHHn+kV+4gRgkgCRbdoDqoGfpaDFs877DYX9n4z6FrAIZ4PES8TNKhatifpn9NdQYWA+IkU8CuvlEKGuFpKRi/k7JLos/gHi2hy7QUwgtRvcefvD/vgQZOVw/mGR9Q== Generated-by-Nova\n"
						}
					}
				}
			});
		}

		/// <summary>
		/// 	Creates key pair. POST/v2/​{tenant_id}​/os-keypairs. 
		/// </summary>
		/// <remarks>
		/// 	Anthony, 4/15/2015. 
		/// </remarks>
		/// <param name="tenantId">
		/// The tenant Id.
		/// </param>
		/// <param name="request">
		/// 	The request. 
		/// </param>
		/// <returns>
		/// 	The new key pair. 
		/// </returns>
		/// <seealso cref="M:Caas.OpenStack.API.Interfaces.IOpenStackApiKeyPairController.CreateKeyPair(KeyPairCreateRequest)"/>
		[HttpPost]
		[Route("{tenantId}/os-keypairs")]
		public Task<KeyPairDetailResponse> CreateKeyPair(string tenantId, KeyPairCreateRequest request)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Deletes the key pair described by keypairName
		/// 		   DELETE/v2/​{tenant_id}​/os-keypairs/​{keypair_name}. 
		/// </summary>
		/// <remarks>
		/// 	Anthony, 4/15/2015. 
		/// </remarks>
		/// <param name="tenantId">
		/// The tenant Id.
		/// </param>
		/// <param name="keypairName">
		/// 	Name of the key pair. 
		/// </param>
		/// <returns>
		/// 	A Task. 
		/// </returns>
		/// <seealso cref="M:Caas.OpenStack.API.Interfaces.IOpenStackApiKeyPairController.DeleteKeyPair(string)"/>
		[HttpDelete]
		[Route("{tenantId}/os-keypairs")]
		public Task DeleteKeyPair(string tenantId, string keypairName)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Updates the key pair described by keypairName 
		/// 		  GET/v2/​{tenant_id}​/os-keypairs/​{keypair_name}. 
		/// </summary>
		/// <remarks>
		/// 	Anthony, 4/15/2015. 
		/// </remarks>
		/// <param name="tenantId">
		/// The tenant Id.
		/// </param>
		/// <param name="keypairName">
		/// 	Name of the key pair. 
		/// </param>
		/// <returns>
		/// 	A KeyPairDetailResponse; 
		/// </returns>
		/// <seealso cref="M:Caas.OpenStack.API.Interfaces.IOpenStackApiKeyPairController.UpdateKeyPair(string)"/>
		[HttpPost]
		[Route("{tenantId}/os-keypairs/{keypairName}")]
		public Task<KeyPairDetailResponse> GetKeyPair(string tenantId, string keypairName)
		{
			return Task.FromResult(new KeyPairDetailResponse());
		}
	}
}