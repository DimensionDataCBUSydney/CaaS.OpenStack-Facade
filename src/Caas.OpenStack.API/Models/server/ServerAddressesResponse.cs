// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServerAddressesResponse.cs" company="">
//   
// </copyright>
// <summary>
//   A server addresses response.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System.Runtime.Serialization;

namespace Caas.OpenStack.API.Models.server
{
	/// <summary>	A server addresses response. </summary>
	/// <remarks>	Anthony, 4/13/2015. </remarks>
	public class ServerAddressesResponse
	{
		/// <summary>	Gets or sets the addresses. </summary>
		/// <value>	The addresses. </value>
		[DataMember(Name = "addresses")]
		public IpAddressCollection Addresses { get; set; }
	}
}