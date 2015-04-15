using System.Threading.Tasks;
using Caas.OpenStack.API.Models.network;

namespace Caas.OpenStack.API.Interfaces
{
	/// <summary>	Interface for open stack API network subnets controller. 
	/// 			GET/v2.0/subnetsList subnets
	/// Lists subnets to which the specified tenant has access.
	///
	///  detail
	/// POST/v2.0/subnetsCreate subnet
	/// Creates a subnet on a specified network.
	///
	///  detail
	/// POST/v2.0/subnetsBulk create subnet
	/// Creates multiple subnets in a single request. Specify a list of subnets in the request body.
	///
	///  detail
	/// GET/v2.0/subnets/​{subnet_id}​Show subnet
	/// Shows information for a specified subnet.
	///
	///  detail
	/// PUT/v2.0/subnets/​{subnet_id}​Update subnet
	/// Updates a specified subnet.
	///
	///  detail
	/// DELETE/v2.0/subnets/​{subnet_id}​Delete subnet
	/// Deletes a specified subnet.
	/// 			</summary>
	/// <remarks>	Anthony, 4/15/2015. </remarks>
	public interface IOpenStackApiNetworkSubnetsController
	{
		/// <summary>	Gets the subnets.
		/// 			Equivalent GET/v2.0/subnets </summary>
		/// <returns>	The subnets. </returns>
		Task<SubnetCollectionResponse> GetSubnets();

		/// <summary>	Creates a subnet. 
		/// 			POST/v2.0/subnets</summary>
		/// <param name="request">	The request. </param>
		/// <returns>	The new subnet. </returns>
		Task<SubnetDetailResponse> CreateSubnet(SubnetCreateRequest request);

		/// <summary>	Gets a subnet.
		/// 			GET/v2.0/subnets/​{subnet_id} </summary>
		/// <param name="subnetId">	Identifier for the subnet. </param>
		/// <returns>	The subnet. </returns>
		Task<SubnetDetailResponse> GetSubnet(string subnetId);

		/// <summary>	Updates the subnet described by subnetId.
		/// 			PUT/v2.0/subnets/​{subnet_id}​ </summary>
		/// <param name="subnetId">	Identifier for the subnet. </param>
		/// <returns>	A Task&lt;SubnetDetailResponse&gt; </returns>
		Task<SubnetDetailResponse> UpdateSubnet(string subnetId);

		/// <summary>	Deletes the subnet described by subnetId.
		/// 			 DELETE/v2.0/subnets/​{subnet_id} </summary>
		/// <param name="subnetId">	Identifier for the subnet. </param>
		/// <returns>	A Task. </returns>
		Task DeleteSubnet(string subnetId);
	}
}
